using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Database;
using System;

namespace Solution.Web.App
{
    public static class Extensions
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.AddCriptography(Guid.NewGuid().ToString());
            services.AddJsonWebTokenSettings(Guid.NewGuid().ToString());
            services.AddLogger(configuration);
            services.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
        }
    }
}
