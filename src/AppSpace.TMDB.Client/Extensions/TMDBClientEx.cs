using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.TMDB.Client.Extensions
{
    public static class TMDBClientEx
    {
        public static IServiceCollection AddTMDBClientOptions(IServiceCollection services, ITMDBApiClientOptions options)
        {
            services.AddTransient<ITMDBApiClientOptions>(options);

            return services;
        }
    }
}
