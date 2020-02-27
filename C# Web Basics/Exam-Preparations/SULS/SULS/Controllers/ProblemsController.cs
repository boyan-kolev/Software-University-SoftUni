using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProblemInputModel input)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return this.Redirect("/Problems/Create");
            }

            if (input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Redirect("/Problems/Create");
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.Create(input.Name, input.Points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            var details = this.problemsService.GetDetails(id);

            return this.View(details);
        }

    }
}
