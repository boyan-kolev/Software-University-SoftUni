using IRunesApp.Services;
using IRunesApp.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService homeService;

        public HomeController(IUsersService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                LoginViewModel viewModel = new LoginViewModel();
                viewModel.Username = this.homeService.GetUsername(this.User);

                return this.View(viewModel, "Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }



    }
}
