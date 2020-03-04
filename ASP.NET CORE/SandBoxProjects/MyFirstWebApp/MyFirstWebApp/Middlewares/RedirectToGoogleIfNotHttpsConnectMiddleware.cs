using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Middlewares
{
    public class RedirectToGoogleIfNotHttpsConnectMiddleware
    {
        private readonly RequestDelegate next;

        public RedirectToGoogleIfNotHttpsConnectMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.IsHttps)
            {
                await this.next(context);
            }
            else
            {
                context.Response.StatusCode = 307;
                context.Response.Headers["Location"] = "https://google.com";
            }
        }
    }
}
