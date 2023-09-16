using System;
using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using AppSpace.TMDB.Contracts.Responses;
using AppSpace.TMDB.Client.Interfaces;
using AppSpace.TMDB.Contracts.Requests;

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

        public async Task<PaginatedResult<TMDBMovieResponse>> GetMovieDiscovery(DiscoverMoviesRequest filters)
        {
            var options = new RestClientOptions(_options.DiscoverMoviesUrl);
            var restClient = new RestClient(options);
            var request = new RestRequest("");
            foreach(var kvp in filters.ToDictionary())
            {
                request.AddParameter(kvp.Key, kvp.Value);
            }
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_options.ApiToken}");
            var response = await restClient.GetAsync(request);
            return JsonSerializer.Deserialize<PaginatedResult<TMDBMovieResponse>>(response.Content);
        }
    }
}
