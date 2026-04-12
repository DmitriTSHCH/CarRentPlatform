using CarRentPlatform.Logic.RepositoriesInterfaces;
using CarRentPlatform.Persistence.Repositories;

namespace CarRentPlatform.API.Extensions
{
    public static class ApplicationsServicesExtension
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            return services;
        }
    }
}
