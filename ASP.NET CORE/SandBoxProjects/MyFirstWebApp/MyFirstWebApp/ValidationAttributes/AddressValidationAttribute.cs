using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ValidationAttributes
{
    public class AddressValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().StartsWith("ул.") == false)
            {
                return new ValidationResult(@"Адреса трябва да започва с ""ул.""");
            }

            return ValidationResult.Success;
        }
    }
}
