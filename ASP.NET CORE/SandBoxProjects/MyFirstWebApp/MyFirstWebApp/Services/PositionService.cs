using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Services
{
    public class PositionService : IPositionService
    {
        public IEnumerable<SelectListItem> GetAll()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Junior Dev"},
                new SelectListItem { Value = "2", Text = "Regular Dev"},
                new SelectListItem { Value = "3", Text = "Junior QA"}
            };
        }
    }
}
