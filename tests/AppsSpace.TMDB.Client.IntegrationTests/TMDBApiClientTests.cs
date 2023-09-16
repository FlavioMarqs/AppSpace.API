using AppSpace.TMDB.Client;
using AppSpace.TMDB.Client.Interfaces;
using AppSpace.TMDB.Contracts.Responses;
using FluentAssertions;
using NUnit.Framework;
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

        [Test]
        public async Task DiscoverMoviesAsync_Should_Return_Valid_Response()
        {
            PaginatedResult<TMDBMovieResponse> response = null;
            Assert.DoesNotThrowAsync(async () => response = await _client.GetMovieDiscovery(1));
            response.Should().NotBeNull();

        }
    }
}