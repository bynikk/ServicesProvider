using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicesProvider.Data;
using ServicesProvider.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicesProvider.Data.Repository;
using ServicesProvider.Models.Entities;
using ServicesProvider.Service;
using ServicesProvider.Models.Interfaces;

namespace ServicesProvider
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration; 
        public void ConfigureServices(IServiceCollection services)
        {
            // connectiong config from appsetting.json
            Configuration.Bind("Project", new Config());

            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer (
                    "Server=(localdb)\\MSSQLLocalDB;Database=ServicesProvider;Trusted_Connection=True;MultipleActiveResultSets=true");
            }).AddIdentity<ApplicationUser, ApplicationRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                }) 
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddTransient<IAllUsersAds, UsersAdContainer>();
            services.AddTransient<IUsersAdsCategory, CategoryContainer>();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Admin/Login";
                config.AccessDeniedPath = "/Home/AccessDenied";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(RolesModel.Administrator, builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, RolesModel.Administrator); 
                });

                options.AddPolicy(RolesModel.User, builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, RolesModel.Administrator)
                        || x.User.HasClaim(ClaimTypes.Role, RolesModel.User));
                });
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            using var scope = app.ApplicationServices.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DatabaseInitializer1.Initial(context);
        }
    }
}
