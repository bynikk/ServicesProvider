using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Models;
using ServicesProvider.Models.Entities;

namespace ServicesProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                DatabaseInitializer.Init(scope.ServiceProvider);
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class DatabaseInitializer
    {
        internal static void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser()
            {
                UserName = "Admin",
                LastName = "Admin",
                FirstName = "Admin"
            };
            
            var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, RolesModel.Administrator)).GetAwaiter()
                    .GetResult();
            }
            
        }
    }
}
