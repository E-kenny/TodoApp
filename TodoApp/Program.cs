using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using TodoRepositories.Implementations;
using TodoRepositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace TodoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}