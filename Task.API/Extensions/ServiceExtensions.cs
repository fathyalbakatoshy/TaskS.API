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
            // إضافة DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // إعداد Identity
            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // تسجيل UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // تسجيل AuthService
            services.AddScoped<AuthService>();

            // إضافة الكاش
            services.AddMemoryCache();

            // إضافة Controllers
            services.AddControllers();

            // تكوين سياسات التفويض
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            });
        }
    }
}
