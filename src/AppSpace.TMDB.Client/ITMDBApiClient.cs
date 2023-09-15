using AppSpace.TMDB.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSpace.TMDB.Client
{
    public interface ITMDBApiClient
    {
        Task<IEnumerable<ITMDBMovieResponse>> GetMovieDiscovery();
    }
}
