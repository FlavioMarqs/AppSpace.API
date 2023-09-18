using AppSpace.Repositories.Entities;
using AppSpace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Repositories
{
    public class TopRatedMoviesRepository : ITopRatedMoviesRepository
    {
        private readonly BeezyDbContext _dbContext;

        public TopRatedMoviesRepository(BeezyDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int weekNumber, int roomsCount, string roomSize)
        {
            var sessions = _dbContext.Session.Where(d => d.Room.Size.Equals(roomSize))
                 .Include(d => d.Movie)
                 .ToList();

            var movies = sessions.GroupBy(d => d.Movie)
                .Select(d => new { Movie = d.Key, Count = d.Sum(d => d.SeatsSold) })
                .OrderByDescending(d => d.Count)
                .Skip(weekNumber * roomsCount)
                .Take(roomsCount)
                .Select(d => d.Movie)
                .ToList();

            if (movies.Count != roomsCount)
            {
                int moviesToTake = roomsCount - movies.Count;
                var moreMovies = sessions
                    .GroupBy(d => d.Movie)
                    .Select(d => new { Movie = d.Key, Count = d.Sum(d => d.SeatsSold) })
                    .OrderByDescending(d => d.Count)
                    .Take(moviesToTake)
                    .Select(d => d.Movie)
                    .ToList();

                movies.AddRange(moreMovies);
            }

            return Task.FromResult<IEnumerable<Movie>>(movies);
        }
    }
}
