using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.Handlers.MappingProfiles;
using AppSpace.TMDB.Client;
using AppSpace.TMDB.Client.Interfaces;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers.IntegrationTests
{
    public class SmartBillboardCommandHandlerTests
    {
        private SmartBillboardCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            var options = new TMDBApiClientOptions()
            {
                //todo: read this from secretsStore
                ApiKey = "c40345539d01ee7222892ab24b491cbb",
                ApiToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJjNDAzNDU1MzlkMDFlZTcyMjI4OTJhYjI0YjQ5MWNiYiIsInN1YiI6IjY1MDQyNTY5ZWEzN2UwMDBlM2E1Mjc3NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.oxuJaZwIvh3mQ5AelOaFWnzlc1gUg5LluMLJ5xzptYw"
            };

            var client = new TMDBApiClient(options);

            MapperConfiguration mapperConfig = new MapperConfiguration(
                  cfg =>
                  {
                      cfg.AddProfile(new HandlersMappingProfile());
                  });

            IMapper mapper = new Mapper(mapperConfig);
            _handler = new SmartBillboardCommandHandler(mapper, client);
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 1)]
        [TestCase(2, 2, 2)]
        [TestCase(7, 8, 71)]
        public async Task HandleAsync_Should_Return_Expected_Results(int smallRoomsCount, int bigRoomsCount, int daysDuration)
        {
            var command = new SmartBillboardCommand
            {
                BigRoomsCount = bigRoomsCount,
                SmallRoomsCount = smallRoomsCount,
                TimeInterval = TimeSpan.FromDays(daysDuration),
                Filters = new Dictionary<string, string>()
                {
                    {"include_adult", "false" },
                    {"include_video", "false" },
                    {"release_date.gte", "2000-01-01" },
                    {"release_date.lte", "2024-01-01" }
                }
            };
            SmartBillboardDTO result = null;
            Assert.DoesNotThrowAsync(async () => result = await _handler.HandleAsync(command));
            result.Should().NotBeNull();
            var expectedWeekCount = daysDuration % 7 == 0 ? daysDuration / 7 : (daysDuration / 7) + 1;
            result.BigRoomMovies.Should().HaveCount(expectedWeekCount);
            foreach (var week in result.BigRoomMovies)
            {
                week.Values.Should().HaveCount(bigRoomsCount);
            }
            foreach (var week in result.SmallRoomMovies)
            {
                week.Values.Should().HaveCount(smallRoomsCount);
            }

            result.SmallRoomMovies.Should().HaveCount(expectedWeekCount);
        }
    }
}
