using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace task_3_web_api_.Models
{
    public class DemidovichMiddleware
    {
        private readonly RequestDelegate _delegate;

        public DemidovichMiddleware(RequestDelegate nextDelegate)
        {
            _delegate = nextDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            double x = 100;
            switch (context.Request.Query["num"])
            {
                case "1":
                {
                    var tmp = (Math.Sin(x) - ((1 / 3) * Math.Sin(3 * x)) + ((1 / 5) * Math.Sin(5 * x)));
                    await context.Response.WriteAsync($"Formula #1\nResult is {tmp}");
                    break;
                }

                case "2":
                {
                    var tmp = (Math.Sqrt(x + System.Math.Sqrt(x + Math.Sqrt(x))));
                    await context.Response.WriteAsync($"Formula #1\nResult is {tmp}");
                    break;
                }

                default:
                    await _delegate.Invoke(context);
                    break;
            }
        }
    }
}
