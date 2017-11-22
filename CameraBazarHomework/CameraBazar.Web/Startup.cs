namespace CameraBazar.Web
{
    using System;
    using CameraBazar.Data;
    using CameraBazar.Data.Models;
    using CameraBazar.Services;
    using CameraBazar.Services.Implementations;
    using CameraBazar.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CameraBazarDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(option=>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;

            })

                .AddEntityFrameworkStores<CameraBazarDbContext>()
                .AddDefaultTokenProviders();

            //services.AddDomainServices();

            services.AddMvc();

            services.AddTransient<ICameraService, CameraService>();
            services.AddTransient<IProfileService, ProfileService>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<CameraBazarDbContext>().Database.Migrate();
                    //serviceScope.ServiceProvider.GetService<ISeedService>().SeedDatabase().Wait();
                }
            }
            catch (Exception ex)
            {
                // I'm using Serilog here, but use the logging solution of your choice.
                System.Console.WriteLine(ex.Message);
            }
            app.UseDatabaseMigration();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
           
        }
    }
}
