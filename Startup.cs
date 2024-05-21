using FptLongChauApp.Models;
using FptLongChauApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FptLongChauApp
{
    public class Startup {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Sign up for Identity services
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
            services.AddSession();


            // Access IdentityOptions
            services.Configure<IdentityOptions>(options => {
                // Set up Password
                options.Password.RequireDigit = false; // Number is not required
                options.Password.RequireLowercase = false; // Does not require lowercase letters
                options.Password.RequireNonAlphanumeric = false; // Does not capture special characters
                options.Password.RequireUppercase = false; // Printing is not required
                options.Password.RequiredLength = 3; // Minimum number of characters for password
                options.Password.RequiredUniqueChars = 1; // Number of distinct characters

                // User configuration.
                options.User.AllowedUserNameCharacters = // characters named user
                                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });

            // Cookie Configuration
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/login/"; 
                options.LogoutPath = $"/logout/";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();

            services.Configure<RouteOptions>(options => {
                options.AppendTrailingSlash = false; // Add a / to the end of the URL
                options.LowercaseUrls = true; // lowercase url
                options.LowercaseQueryStrings = false; // do not force the query in the url to be in lower case
            });

            /*services.AddAuthorization(options =>
            {
                // User thỏa mãn policy khi có roleclaim: permission với giá trị manage.user
                options.AddPolicy("AdminDropdown", policy => {
                    policy.RequireClaim("permission", "manage.user");
                });
            });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for Drugion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();   // Phục hồi thông tin đăng nhập (xác thực)
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async (context) => {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Page not found!");
            });
        }
    }
}
