using CarRentPlatform.Logic.RepositoriesInterfaces;
using CarRentPlatform.Persistence;
using CarRentPlatform.Persistence.Repositories;

namespace CarRentPlatform.API.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IRentalPeriodRepository, RentalPeriodRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
