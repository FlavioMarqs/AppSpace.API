using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppSpace.Repositories.Extensions
{
    public static class RepositoriesEx
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<BeezyDbContext>(options =>
            {
                options.EnableServiceProviderCaching();
                options.UseSqlServer(config["Databases:BeezyDBConnectionString"]);
            });
        }
    }
}
