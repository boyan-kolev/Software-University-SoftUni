using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Services;
using MyFirstWebApp.ViewModels.NavBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IYearsService yearsService;

        public NavBarViewComponent(IYearsService yearsService)
        {
            this.yearsService = yearsService;
        }

        public IViewComponentResult Invoke(int years)
        {
            NavBarViewModel viewModel = new NavBarViewModel()
            {
                Years = this.yearsService.GetLastYears(years)
            };

            return this.View(viewModel);
        }
    }
}
