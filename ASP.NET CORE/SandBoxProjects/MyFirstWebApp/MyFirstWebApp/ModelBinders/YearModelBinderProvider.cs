using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ModelBinders
{
    public class YearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            bool isValidModelType = context.Metadata?.ModelType == typeof(int);
            bool isValidInputType = context.Metadata?.Name?.ToLower() == "year";

            if (isValidInputType && isValidModelType)
            {
                return new YearModelBinder();
            }

            return null;
        }
    }
}
