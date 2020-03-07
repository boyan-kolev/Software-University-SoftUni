using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ModelBinders
{
    public class YearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string valueFromRequestAsString = bindingContext.ValueProvider.GetValue("date").FirstOrDefault();

            if (valueFromRequestAsString == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            else
            {
                DateTime date = DateTime.Parse(valueFromRequestAsString);
                bindingContext.Result = ModelBindingResult.Success(date.Year);
            }

            return Task.CompletedTask;
        }
    }
}
