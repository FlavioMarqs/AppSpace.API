using AppSpace.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSpace.Repositories.Interfaces
{
    public interface ITopRatedMoviesRepository
    {
        Task<IEnumerable<Movie>> GetTopRatedMoviesAsync(int weekNumber, int roomsCount, string roomSize);
    }
}
