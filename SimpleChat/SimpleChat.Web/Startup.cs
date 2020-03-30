using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleChat.Web.Data;
using Microsoft.Extensions.Configuration;
using SimpleChat.MiddleWare;

namespace SimpleChat.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SimpleChatDBContext>( config=>
            {
                config.UseSqlServer(Configuration.GetConnectionString("SimpleChatContext"),
                    b => b.MigrationsAssembly("SimpleChat.Persistence"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>( config=>
            {
                config.Password.RequiredLength = 5;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric=false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<SimpleChatDBContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Home/";
            });

            services.AddSignalR();
            services.AddControllersWithViews();
            
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          

            app.UseRouting();
           
            app.UseAuthentication();
            
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<ChatHub>("/chatHub");
            });

        }
    }
}
