using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AppSpace.TMDB.Client.Interfaces;

namespace AppSpace.TMDB.Client.Extensions
{
    public static class TMDBClientEx
    {
        private const string ApiKey = "ApiKey";
        private const string ApiToken = "ApiToken";

        public static IServiceCollection AddTMDBClientOptions(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<ITMDBApiClientOptions>((a) => new TMDBApiClientOptions
            {
                ApiKey = GetSecret(ApiKey, config),
                ApiToken = GetSecret(ApiToken, config)
            });

            services.AddTransient<ITMDBApiClient, TMDBApiClient>();

            return services;
        }

        private static string GetSecret(string apiKey, IConfiguration config)
        {
            //todo: refactor this: move keys to a secure secretsStore
            return config[$"TMDBApiClientOptions:{apiKey}"];
        }
    }
}
