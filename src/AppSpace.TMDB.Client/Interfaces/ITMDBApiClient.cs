using AppSpace.TMDB.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSpace.TMDB.Client.Interfaces
{
    public interface ITMDBApiClient
    {
        Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscovery(int pageNumber);

        Task<AuthenticationResponse> AuthenticateAsync();
    }
}
