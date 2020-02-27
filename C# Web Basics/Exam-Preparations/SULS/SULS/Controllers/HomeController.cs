using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.View();
            }

            IEnumerable<AllProblemsViewModel> allProblems = this.problemsService.GetAll();

            ProblemsCollectionViewModel problems = new ProblemsCollectionViewModel()
            {
                Problems = allProblems
            };

            return this.View(problems, "IndexLoggedIn");

        }
    }
}
