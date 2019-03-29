using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MVCData.Controllers;
using MVCData.Models;

namespace MVCData
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Dependency Injection
            //DO// change it!!!/// services.AddSingleton<ICakeService, NewUserService>();

            services.AddSingleton<IPersonService, NewUserService>();
            //session////////////////////
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                //set a short timeout for easy testing
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = false;
                //make the session cookie essential
                options.Cookie.IsEssential = true;
            });


            //MVC
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler();
            //    app.UseStaticFiles();
            //}
            //app.UseDefaultFiles();
           // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            //app.UseCookiePolicy();

            app.UseMvcWithDefaultRoute();

        }
    }
}