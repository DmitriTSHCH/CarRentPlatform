using CarRentPlatform.API.Extensions;
using CarRentPlatform.API.Policy;
using CarRentPlatform.Application.Intefaces.Auth;
using CarRentPlatform.Infrastructure;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using CarRentPlatform.Persistence;
using CarRentPlatform.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Data;
namespace CarRentPlatform.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.Configure<RoleOptions>(builder.Configuration.GetSection(nameof(RoleOptions)));

        builder.Services.AddDbContext<CarRentPlatformDbContext>();
        builder.Services.AddRepositories();
        builder.Services.AddApplicationsServices();

        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
        builder.Services.AddTransient<IJwtProvider, JwtProvider>();
        builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicies();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
