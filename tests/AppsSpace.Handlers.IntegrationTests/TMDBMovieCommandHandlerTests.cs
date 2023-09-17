using AppSpace.Handlers.Commands;
using AppSpace.Handlers.MappingProfiles;
using AppSpace.Repositories;
using AppSpace.TMDB.Client;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Handlers.IntegrationTests
{
    public class TMDBMovieCommandHandlerTests
    {
        private TMDBMovieCommandHandler _handler;
        private BeezyDbContext _dbContext;

        [SetUp] 
        public void SetUp() 
        {
            //setup DB:
            var config = new Mock<IConfiguration>();
            config.Setup(d => d["Databases:BeezyDBConnectionString"]).Returns("Server=tcp:beezybetest.database.windows.net,1433;Initial Catalog=beezycinema;Persist Security Info=False;User ID=betestuser;Password=ReadOnly!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var _dbContext = new BeezyDbContext(config.Object);

            //setup AutoMapper:
            MapperConfiguration mapperConfig = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.AddProfile(new HandlersMappingProfile());
                    });
            IMapper mapper = new Mapper(mapperConfig);

            //setup TMDBClient:
            var options = new TMDBApiClientOptions()
            {
                //todo: read this from secretsStore
                ApiKey = "c40345539d01ee7222892ab24b491cbb",
                ApiToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJjNDAzNDU1MzlkMDFlZTcyMjI4OTJhYjI0YjQ5MWNiYiIsInN1YiI6IjY1MDQyNTY5ZWEzN2UwMDBlM2E1Mjc3NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.oxuJaZwIvh3mQ5AelOaFWnzlc1gUg5LluMLJ5xzptYw"
            };

            var client = new TMDBApiClient(options);
            _handler = new TMDBMovieCommandHandler(mapper, client);
        }

        [TestCase("Se7en")]
        [TestCase("Pulp Fiction")]
        [TestCase("Reservoir Dogs")]
        [TestCase("Barbie")]
        public async Task HandleAsync_Should_Return_Expected_Values(string originalTitle, int releaseYear = 0)
        {
            var command = new TMDBMovieCommand
            {
                OriginalTitle = originalTitle,
                ReleaseYear = releaseYear
            };
            Assert.DoesNotThrowAsync(async () => _handler.HandleAsync(command));
        }
    }
}
