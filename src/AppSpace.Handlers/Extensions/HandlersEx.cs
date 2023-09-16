using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppSpace.Repositories.Extensions;
using AppSpace.Handlers.DTOs;

namespace AppSpace.Handlers.Extensions
{
    public static class HandlersEx
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<ICommandHandler<SmartBillboardCommand, SmartBillboardDTO>>();
            services.AddTransient<ICommandHandler<SmartBillboardQuery, SmartBillboardDTO>>();

            services.AddRepositories(config);

            return services;
        }
    }
}
