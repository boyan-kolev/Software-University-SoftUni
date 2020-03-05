using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Filters
{
    public class ResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.Result = null;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
