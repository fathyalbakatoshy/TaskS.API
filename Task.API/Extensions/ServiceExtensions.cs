using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Task.Repository;
using Task.Core.Services;
using Microsoft.AspNetCore.Identity;
using Task.Core.Entities;
using Task.Core.Interfaces;
using Task.Repository.Data;

namespace Task.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<AuthService>();

            services.AddMemoryCache();

            services.AddControllers();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            });
        }
    }
}
