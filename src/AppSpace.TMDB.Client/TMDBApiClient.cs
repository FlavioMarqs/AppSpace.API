using System;
using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using AppSpace.TMDB.Contracts.Responses;
namespace AppSpace.TMDB.Client
{
    public class TMDBApiClient : ITMDBApiClient
    {
        private readonly ITMDBApiClientOptions _options;
        private readonly RestClient _restClient;

        public TMDBApiClient(ITMDBApiClientOptions options) 
        { 
            _options = options ?? throw new ArgumentNullException(nameof(options));
            var restClientOptions = new RestClientOptions(_options.AuthenticationUrl);
            _restClient = new RestClient(restClientOptions);
        }

        public async Task<IEnumerable<ITMDBMovieResponse>> GetMovieDiscovery()
        {
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            var response = await _restClient.GetAsync(request);
            return JsonSerializer.Deserialize<IEnumerable<ITMDBMovieResponse>>(response.Content);
        }
    }
}
