using AppSpace.TMDB.Client;
using AppSpace.TMDB.Client.Interfaces;
using AppSpace.TMDB.Contracts.Responses;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AppsSpace.TMDB.Client.IntegrationTests
{
    public class TMDBApiClientTests
    {
        private ITMDBApiClient _client;

        [SetUp]
        public void Setup()
        {
            var options = new TMDBApiClientOptions()
            {
                //todo: read this from secretsStore
                ApiKey = "c40345539d01ee7222892ab24b491cbb",
                ApiToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJjNDAzNDU1MzlkMDFlZTcyMjI4OTJhYjI0YjQ5MWNiYiIsInN1YiI6IjY1MDQyNTY5ZWEzN2UwMDBlM2E1Mjc3NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.oxuJaZwIvh3mQ5AelOaFWnzlc1gUg5LluMLJ5xzptYw"
            };

            _client = new TMDBApiClient(options);
        }

        [Test]
        public async Task AuthenticateAsync_Should_Return_Valid_Response()
        {
            AuthenticationResponse response = null;
            Assert.DoesNotThrowAsync(async ()=> response = await _client.AuthenticateAsync());
            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
            response.StatusCode.Should().Be(1);
            response.StatusMessage.Should().Be("Success.");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DiscoverMoviesAsync_Should_Return_Valid_Response(int pageNumber)
        {
            PaginatedResult<TMDBMovieResponse> response = null;
            var request = new AppSpace.TMDB.Contracts.Requests.DiscoverMoviesRequest() 
            { 
                IncludeAdult = false, 
                Keywords = new string[] 
                {
                    "war",
                    "science-fiction",
                    "mystery",
                    "thriller"
                },
                Language = "en",
                PrimaryReleaseDateGte = DateTime.Parse("2000-01-01"),
                PrimaryReleaseDateLte = DateTime.Parse("2024-01-01"),
                SortBy = "vote_average.desc"
            };

            Assert.DoesNotThrowAsync(async () => response = await _client.GetMovieDiscoveryAsync(request, pageNumber));
            response.Should().NotBeNull();
            response.PageNumber.Should().Be(pageNumber);
            response.Results.Should().HaveCount(20);
        }

        [TestCase("Pulp Fiction")]
        [TestCase("Reservoir Dogs")]
        [TestCase("Se7en")]
        public async Task SearchMovieByTitleAsync_Should_Return_Expected_Results(string originalTitle)
        {
            PaginatedResult<TMDBMovieResponse> response = null;
            Assert.DoesNotThrowAsync(async () => response = await _client.SearchMovieByTitleAsync(originalTitle));
            response.Should().NotBeNull();
            response.PageNumber.Should().Be(1);
            response.Results.Should().HaveCountGreaterThan(0);
        }
    }
}