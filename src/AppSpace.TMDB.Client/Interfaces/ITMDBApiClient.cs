using AppSpace.TMDB.Contracts.Requests;
using AppSpace.TMDB.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSpace.TMDB.Client.Interfaces
{
    public interface ITMDBApiClient
    {
        Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscovery(DiscoverMoviesRequest request, int pageNumber = 1);

        Task<AuthenticationResponse> AuthenticateAsync();
    }
}
