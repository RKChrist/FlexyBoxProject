using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });

            services.AddAutoMapperProfile();
            return services;
        }

        public static void AddAutoMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

        }
    }
}
