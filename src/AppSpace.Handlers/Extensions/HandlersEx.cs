using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.Handlers.Extensions
{
    public static class HandlersEx
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<SmartBillboardCommand, ISmartBillboardDTO>>();

            return services;
        }
    }
}
