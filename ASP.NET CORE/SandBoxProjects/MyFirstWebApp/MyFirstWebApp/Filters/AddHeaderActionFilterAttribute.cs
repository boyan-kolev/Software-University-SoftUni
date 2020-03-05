using Microsoft.AspNetCore.Mvc.Filters;
using MyFirstWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Filters
{
    public class AddHeaderActionFilterAttribute : IAsyncActionFilter
    {
        private readonly IYearsService yearsService;

        public AddHeaderActionFilterAttribute(IYearsService yearsService)
        {
            this.yearsService = yearsService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers["years"] = string.Join(",", yearsService.GetLastYears(5));

            await next();
        }
    }
}
