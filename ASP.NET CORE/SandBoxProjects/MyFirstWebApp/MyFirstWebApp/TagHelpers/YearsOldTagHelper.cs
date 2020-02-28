using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.TagHelpers
{
    [HtmlTargetElement("h1", Attributes = "year-of-birthdate")]
    public class YearsOldTagHelper : TagHelper
    {
        public int YearOfBirthdate { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int yaersOld = DateTime.UtcNow.Year - YearOfBirthdate;

            output.Content.SetContent(yaersOld.ToString());
            base.Process(context, output);
        }
    }
}
