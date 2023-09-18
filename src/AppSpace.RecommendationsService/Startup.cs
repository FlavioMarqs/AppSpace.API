using AppSpace.Handlers.Extensions;
using AppSpace.RecommendationsService.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;
using System.Reflection;

namespace AppSpace.RecommendationsService
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseStaticFiles();
            
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = "";
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<IConfiguration>(Configuration);
            services.AddHttpContextAccessor();
            services.AddLogging();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AppSpace Recommendations Service",
                    Description = ""
                });

            });
          
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHandlers(Configuration);
            //services.AddTransient<RecommendationsController>();
            services.AddRouting();
            services.AddAuthorizationCore();
            services.AddMvcCore();
            services.AddControllers();
        }
    }
}
