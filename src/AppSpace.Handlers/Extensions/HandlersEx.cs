using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppSpace.Repositories.Extensions;
using AppSpace.Handlers.DTOs;
using AppSpace.TMDB.Client.Extensions;

namespace AppSpace.Handlers.Extensions
{
    public static class HandlersEx
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services, IConfiguration config)
        {
            services.AddRepositories(config);
            services.AddTMDBClientOptions(config);

            services.AddTransient<ICommandHandler<SmartBillboardCommand, SmartBillboardDTO>, SmartBillboardCommandHandler>();
            services.AddTransient<ICommandHandler<SmartBillboardQuery, SmartBillboardDTO>, SmartBillboardQueryHandler>();
            services.AddTransient<ICommandHandler<TMDBMovieCommand, MovieDTO>, TMDBMovieCommandHandler>();
            services.AddTransient<ICommandHandler<ComparisonCommand, SmartBillboardDTO>, ComparisonCommandHandler>();

            return services;
        }
    }
}
