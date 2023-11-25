using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RegistrationApp.Middlewares;
using registrationapp_core;
using registrationapp_core.Services;
using registrationapp_data;
using registrationapp_services;

namespace RegistrationApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<RepositoryDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("registrationapp-data")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ICountryService, CountryService>();
            builder.Services.AddTransient<ICountryRegionService, CountryRegionService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevelopmentPolicy", x =>
                {
                    x.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

                options.AddPolicy("ProductionPolicy", x => 
                { 
                    x.WithOrigins("https://test.ngrok.io")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<RepositoryDbContext>();

                dbContext.Database.Migrate();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("DevelopmentPolicy");
            }
            else
            {
                app.UseCors("ProductionPolicy");
            }

            app.UseMiddleware<ApiResponseMiddleware>();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
