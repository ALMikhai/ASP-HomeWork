using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace task_3_web_api_
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        { 
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            double x = 100; // task_2 begin
//            app.Use(async (httpContext, func) =>
//            {
//                await func.Invoke();
//                await httpContext.Response.WriteAsync($"Result is {x}");
//            });
//            app.Run(async context =>
//            {
//                x = (Math.Sin(x) - ((1 / 3) * Math.Sin(3 * x)) + ((1 / 5) * Math.Sin(5 * x)));
//                await Task.FromResult(0);
//            }); // task_2 end

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Hello", "{controller=Hello}/{action=Index}"); // task_1

                endpoints.MapGet("/demidovich", async context => {
                    await context.Response.WriteAsync($"Result is {x}");
                });
            });
        }
    }
}
