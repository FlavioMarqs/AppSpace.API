using AppSpace.TMDB.Contracts.Requests;
using AppSpace.TMDB.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSpace.TMDB.Client.Interfaces
{
    public interface ITMDBApiClient
    {
        Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscoveryAsync(DiscoverMoviesRequest request, int pageNumber = 1);

        Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscoveryAsync(IDictionary<string, string> filters, int pageNumber = 1);

        Task<PaginatedResult<TMDBMovieResponse>> SearchMovieByTitleAsync(string originalTitle, int releaseYear = 0);

        Task<TMDBMovieImageResponse> GetImagesForMovie(int movieId);

        Task<AuthenticationResponse> AuthenticateAsync();
    }
}
