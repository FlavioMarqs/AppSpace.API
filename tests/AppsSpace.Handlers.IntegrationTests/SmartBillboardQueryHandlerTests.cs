using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.MappingProfiles;
using AppSpace.Repositories;
using AppSpace.TMDB.Client;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers.IntegrationTests
{
    public class SmartBillboardQueryHandlerTests
    {
        private SmartBillboardQueryHandler _handler;

        [SetUp] 
        public void SetUp() 
        {
            //setup DB:
            var config = new Mock<IConfiguration>();
            config.Setup(d => d["Databases:BeezyDBConnectionString"]).Returns("Server=tcp:beezybetest.database.windows.net,1433;Initial Catalog=beezycinema;Persist Security Info=False;User ID=betestuser;Password=ReadOnly!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            
            var dbContext = new BeezyDbContext(config.Object);
            var moviesRepository = new TopRatedMoviesRepository(dbContext);
            MapperConfiguration mapperConfig = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.AddProfile(new HandlersMappingProfile());
                    });

            IMapper mapper = new Mapper(mapperConfig);
            _handler = new SmartBillboardQueryHandler(mapper, moviesRepository);
        }

        [TestCase(1, 3, 3)]
        [TestCase(1, 3, 21)]
        [TestCase(4, 7, 22)]
        [TestCase(10, 10, 91)]
        public async Task HandleAsync_Should_Return_ExpectedData(int smallRoomsCount, int bigRoomsCount, int daysInterval)
        {
            var command = new SmartBillboardCommand()
            {
                SmallRoomsCount = smallRoomsCount,
                BigRoomsCount = bigRoomsCount,
                Filters = new Dictionary<string, string>(),
                TimeInterval = TimeSpan.FromDays(daysInterval)
            };
            SmartBillboardDTO result = null;
            Assert.DoesNotThrowAsync(async () => result = await _handler.HandleAsync(command));
            result.Should().NotBeNull();
            var expectedWeekCount = daysInterval % 7 == 0 ? daysInterval / 7 : daysInterval / 7 + 1;
            result.SmallRoomMovies.Should().HaveCount(expectedWeekCount);
            result.BigRoomMovies.Should().HaveCount(expectedWeekCount);
            result.BigRoomMovies.Sum(d => d.Values.Count()).Should().Be(bigRoomsCount * expectedWeekCount);
            result.SmallRoomMovies.Sum(d => d.Values.Count()).Should().Be(smallRoomsCount * expectedWeekCount);
        }
    }
}
