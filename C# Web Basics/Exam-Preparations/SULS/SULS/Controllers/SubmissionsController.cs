using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/User/Login");
            }

            string problemName = this.submissionsService.GetProblemName(id);
            SubmissionCreateViewModel viewModel = new SubmissionCreateViewModel()
            {
                Name = problemName,
                ProblemId = id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                return this.Redirect("/Submissions/Create");
            }

            if (code.Length < 30 || code.Length > 800)
            {
                return this.Redirect("/Submissions/Create");
            }

            this.submissionsService.Create(code, problemId, this.User);

            return this.Redirect($"/Problems/Details?id={problemId}");
        }

        public HttpResponse Delete(string id)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);
            string problemId = this.submissionsService.GetProblemId(id);

            return this.Redirect($"/");
        }
    }
}
