using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface IProblemsService
    {
        IEnumerable<AllProblemsViewModel> GetAll();

        void Create(string name, int points);

        ProblemDetailsViewModel GetDetails(string problemId);
    }
}
