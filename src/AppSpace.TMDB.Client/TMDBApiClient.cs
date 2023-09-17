using System;
using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using AppSpace.TMDB.Contracts.Responses;
using AppSpace.TMDB.Client.Interfaces;
using AppSpace.TMDB.Contracts.Requests;
using Microsoft.Extensions.Options;

namespace AppSpace.TMDB.Client
{
    public class TMDBApiClient : ITMDBApiClient
    {
        private readonly ITMDBApiClientOptions _options;

        public TMDBApiClient(ITMDBApiClientOptions options) 
        { 
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<AuthenticationResponse> AuthenticateAsync()
        {
            var options = new RestClientOptions(_options.AuthenticationUrl);
            var restClient = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_options.ApiToken}");
            var response = await restClient.GetAsync(request);
            return JsonSerializer.Deserialize<AuthenticationResponse>(response.Content);
        }

        public async Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscoveryAsync(DiscoverMoviesRequest discoverMoviesRequest, int pageNumber = 1)
            => await GetMovieDiscoveryAsync(discoverMoviesRequest.ToDictionary(pageNumber));

        public async Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscoveryAsync(IDictionary<string, string> filters, int pageNumber = 1)
        {
            var options = new RestClientOptions(_options.DiscoverMoviesUrl);
            var restClient = new RestClient(options);
            var request = new RestRequest("");
            foreach (var kvp in filters)
            {
                request.AddQueryParameter(kvp.Key, kvp.Value);
            }
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_options.ApiToken}");
            var response = await restClient.GetAsync(request);
            return JsonSerializer.Deserialize<PaginatedResult<TMDBMovieResponse>>(response.Content);
        }

        public async Task<PaginatedResult<TMDBMovieResponse>> SearchMovieByTitleAsync(string originalTitle, int releaseYear = 0)
        {
            var options = new RestClientOptions(_options.SearchMoviesUrl);
            var restClient = new RestClient(options);
            var request = new RestRequest("");

            if(releaseYear > 0)
                request.AddParameter("primary_release_year", releaseYear);
            
            request.AddParameter("query", originalTitle);
            
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_options.ApiToken}");
            var response = await restClient.GetAsync(request);
            return JsonSerializer.Deserialize<PaginatedResult<TMDBMovieResponse>>(response.Content);
        }
    }
}
