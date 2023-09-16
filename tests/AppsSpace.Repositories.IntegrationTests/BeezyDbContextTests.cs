using AppSpace.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace AppsSpace.TMDB.Client.IntegrationTests
{
    public class BeezyDbContextTests
    {
        private BeezyDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var config = new Mock<IConfiguration>();
            config.Setup(d => d["Databases:BeezyDBConnectionString"]).Returns("Server=tcp:beezybetest.database.windows.net,1433;Initial Catalog=beezycinema;Persist Security Info=False;User ID=betestuser;Password=ReadOnly!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            _dbContext = new BeezyDbContext(config.Object);
        }

        [Test]
        public void QuerySessions_Should_Return_SomeResults()
        {
            var sessions = _dbContext.Session;
            Assert.That(sessions.Count() > 0);
        }

        [Test]
        public void QueryMovies_Should_Return_SomeResults()
        {
            var movies = _dbContext.Movie;
            Assert.That(movies.Count() > 0);
        }

        [Test]
        public void QueryMovieGenres_Should_Return_SomeResults()
        {
            var movieGenres = _dbContext.MovieGenre;
            Assert.That(movieGenres.Count() > 0);
        }

        [Test]
        public void QueryCities_Should_Return_SomeResults()
        {
            var cities = _dbContext.City;
            Assert.That(cities.Count() > 0);
        }

        [Test]
        public void QueryCinemas_Should_Return_SomeResults()
        {
            var cinemas = _dbContext.Cinema;
            Assert.That(cinemas.Count() > 0);
        }

        [Test]
        public void QueryGenres_Should_Return_SomeResults()
        {
            var genres = _dbContext.Genre;
            Assert.That(genres.Count() > 0);
        }

        [Test]
        public void QueryRooms_Should_Return_SomeResults()
        {
            var rooms = _dbContext.Room;
            Assert.That(rooms.Count() > 0);
        }


    }
}