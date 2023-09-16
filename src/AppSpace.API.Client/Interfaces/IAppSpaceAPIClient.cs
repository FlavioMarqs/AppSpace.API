using AppSpace.API.Contracts.GenericRequests;
using AppSpace.API.Contracts.Requests;
using AppSpace.API.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSpace.API.Interfaces
{
    public interface IAppSpaceAPI
    {
        /* Use-case 4: 
         * Viewers can ask the API for all-time recommended movies based 
         * on keywords that they like, 
         * genres they prefer or a combination of both. 
        */
        Task<IList<IRecommendation>> GetAllTimeMovieRecommendationsAsync(IViewerInterests request);

        /* Use-case 5:
         * Viewers can ask the API for recommended upcoming movies 
         * (specifying a period of time from now) based on keywords 
         * that they like, genres they prefer or a combination of both.
         */
        Task<IList<IRecommendation>> GetUpcomingMoviesAsync(IRecommendedUpcomingMoviesRequest request);

        /* Use-case 6:
         * Viewers can ask the API for all-time recommended TV shows based 
         * on keywords that they like, genres they prefer or a combination 
         * of both.
         */
        Task<IList<ITvShow>> GetTvShowsAsync(IViewerInterests request);

        /* Use-case 7:
         * Viewers can ask the API for all-time recommended documentaries 
         * based on topics.
         */
        Task<IList<IDocumentary>> GetAllTimeDocumentariesAsync(IDocumentariesRequest request);

        /* Use-case 8:
         * Theater managers can ask the API for recommended upcoming movies
         * (specifying a period of time from now) based on age rate and genre.
         */
        Task<IList<IRecommendation>> GetUpcomingMoviesAsync(IUpcomingMoviesRequest request);

        /* Use-case 9:
         * Theater managers can ask the API to build a suggested billboard for
         * their theater for a specific period of one or more weeks. The API 
         * receives a period of time and a number of screens and it returns a 
         * suggested movie for each screen and for each week. All the movies
         * will be different from one week to the next.
         */
        Task<IList<IBillboard>> GetSuggestedBillboardsAsync(ISuggestedBillboardsRequest request);

        /* Use-case 10:
         * Theater managers can ask the API to build a suggested intelligent 
         * billboard for their theater for a specific period.
         * 
         * This extra intelligence means: the manager specifies a period of 
         * time and how many screens are in big rooms and how many of them are 
         * in small rooms. According to that, the API finds recommendations 
         * blockbuster genres (for big rooms) and minority genres (for small 
         * rooms) and returns a suggested movie for each screen. All the movies
         * will be different from one week to the next.
         */
        Task<SmartBillboardResponse> GetSmartBillboardAsync(ISmartBillboardRequest request);
    }
}
