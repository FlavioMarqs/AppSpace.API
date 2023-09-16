using AppSpace.Handlers.Extensions;
using AppSpace.RecommendationsService.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSpace.RecommendationsService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLogging();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHandlers();
        }
    }
}
