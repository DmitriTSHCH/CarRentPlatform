using CarRentPlatform.API.Extensions;
using CarRentPlatform.API.Policy;
using CarRentPlatform.Application.Intefaces.Auth;
using CarRentPlatform.Infrastructure;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using CarRentPlatform.Persistence;
using CarRentPlatform.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Data;
namespace CarRentPlatform.API;

public class Program
{
    public static void Main(string[] args)
    {
        System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Введите JWT токен в формате: Bearer {ваш_токен}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddControllers();

        builder.Services.Configure<RoleOptions>(builder.Configuration.GetSection(nameof(RoleOptions)));

        builder.Services.AddDbContext<CarRentPlatformDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddRepositories();

        builder.Services.AddApplicationsServices();

        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
        builder.Services.AddTransient<IJwtProvider, JwtProvider>();
        builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthenticationExeption(builder.Configuration);

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
