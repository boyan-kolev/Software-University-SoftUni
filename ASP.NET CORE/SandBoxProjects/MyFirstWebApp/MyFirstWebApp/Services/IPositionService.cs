using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Services
{
    public interface IPositionService
    {
        IEnumerable<SelectListItem> GetAll();
    }
}
