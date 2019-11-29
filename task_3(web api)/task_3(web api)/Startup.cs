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
using task_3_web_api_.Models;

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
            services.AddTransient<IMessageSender, SmsMessageSender>(); //task_7(как sender узнает инфу о куках или полях сессии?).
            services.AddTransient<MessageService>();
        }

        public void Configure(IApplicationBuilder app, MessageService messageService)
        { 
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles(); // task_6

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

            app.Map("/formula1", Formula_1);// task_3 begin
            app.Map("/formula2", Formula_2);// task_3 end

            app.UseMiddleware<DemidovichMiddleware>(); // task_4
            app.UseMiddleware<OperationsMiddleware>(); // task_5

            app.Run(async context => { await context.Response.WriteAsync(messageService.Send()); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Hello", "{controller=Hello}/{action=Index}"); // task_1
            });
        }

        private static void Formula_1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                double x = 100;
                await context.Response.WriteAsync(
                    $"Result is {(Math.Sin(x) - ((1 / 3) * Math.Sin(3 * x)) + ((1 / 5) * Math.Sin(5 * x)))}");
            });
        }

        private static void Formula_2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                double x = 100;
                await context.Response.WriteAsync(
                    $"Result is {(Math.Sqrt(x + System.Math.Sqrt(x + Math.Sqrt(x))))}");
            });
        }
    }
}
