using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using FinalCaseStudy13.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FinalCaseStudy13.Models;

namespace FinalCaseStudy13
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Given by default to enable Identity authentication
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Adding the Identity feature 
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            //context for connecting to database
            services.AddDbContext<context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IRepo[interface], Repo[class]>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //A third parameter of the type IServiceProvider was added with the instance/object serviceProvider
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateRoles(serviceProvider).Wait();
        }


        ///***********************Method for the role feature********************/
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Customer-Executive", "Account-Executive", "Cashier", "Teller" }; //place the 5th role here inside the curly braces
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var _admin = await UserManager.FindByEmailAsync("admin@gmail.com");
            if (_admin == null)
            {
                var admin = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };
                var createAdmin = await UserManager.CreateAsync(admin, "Admin#2021");
                if (createAdmin.Succeeded)
                    await UserManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
