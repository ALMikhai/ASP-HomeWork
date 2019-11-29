using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace task_3_web_api_.Models
{
    public class OperationsMiddleware
    {
        private readonly RequestDelegate _delegate;
        public OperationsMiddleware(RequestDelegate requestDelegate)
        {
            _delegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            double a = 5;
            double b = 13;

            switch (context.Request.Query["operation"])
            {
                case "+":
                {
                    await context.Response.WriteAsync($"Operation +\nResult is {a + b}");
                    break;
                }
                case "-":
                {
                    await context.Response.WriteAsync($"Operation -\nResult is {a - b}");
                    break;
                }
                case "*":
                {
                    await context.Response.WriteAsync($"Operation *\nResult is {a * b}");
                    break;
                }
                case "/":
                {
                    await context.Response.WriteAsync($"Operation /\nResult is {a / b}");
                    break;
                }
                default:
                {
                    await _delegate.Invoke(context);
                    break;
                }
            }
        }
    }
}
