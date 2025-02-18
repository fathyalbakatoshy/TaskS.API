using Microsoft.EntityFrameworkCore;
using Task.Repository.Data;
using TaskAPI.Middleware;

namespace TaskAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseMiddleware<ExceptionMiddleware>();
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
