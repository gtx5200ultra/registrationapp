using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using registrationapp_core;
using registrationapp_core.Services;
using registrationapp_data;
using registrationapp_services;
using System;

namespace RegistrationApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<RepositoryDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("registrationapp-data")));

            //builder.Services.AddDbContext<RepositoryDbContext>(options =>
            //    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
            //    x => x.MigrationsAssembly(typeof(RepositoryDbContext).Assembly.FullName)));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IUserService, UserService>();


            //services.AddDbContext<RepositoryDbContext>(options =>
            //    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<RepositoryDbContext>();

                dbContext.Database.Migrate();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
