using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppSpace.Repositories.Extensions;

namespace AppSpace.Handlers.Extensions
{
    public static class HandlersEx
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<ICommandHandler<SmartBillboardCommand, ISmartBillboardDTO>>();

            services.AddRepositories(config);

            return services;
        }
    }
}
