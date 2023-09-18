using System;
using System.Collections.Generic;
using System.Text;
using AppSpace.TMDB.Client.Interfaces;

namespace AppSpace.TMDB.Client
{
    public class TMDBApiClientOptions : ITMDBApiClientOptions
    {
        public string BaseUrl => "https://api.themoviedb.org/3/";
        
        public string AuthenticationUrl => $"{BaseUrl}authentication";

        public string DiscoverMoviesUrl => $"{BaseUrl}discover/movie";
        
        public string SearchMoviesUrl => $"{BaseUrl}search/movie";

        public string GetMovieImagesUrl(int movieId) => $"{BaseUrl}movie/{movieId}/images";

        public string ApiKey { get; set; }
        
        public string ApiToken { get; set; }
    }
}
