using Application.Interfaces.Repositories.Common;
using Application.Interfaces.Repositories.ResturantRepository;
using Infrastructure.Data.Common;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, string connectionString)
        {

            services.AddCleanDbContext(connectionString);
            services.AddRepostories();
            return services;
        }


        public static IServiceCollection AddCleanDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, x => { x.CommandTimeout(120); x.UseCompatibilityLevel(110); });
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors(true);

            });
            return services;
        }

        public static void AddRepostories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped(typeof(IResturantRepository), typeof(ResturantRepository));
        }


    }
}
