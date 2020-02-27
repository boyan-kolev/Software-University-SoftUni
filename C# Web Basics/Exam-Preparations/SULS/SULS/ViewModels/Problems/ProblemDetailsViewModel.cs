using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Problems = new List<ProblemSubmissionsViewModel>();
        }

        public string Name { get; set; }
        public IEnumerable<ProblemSubmissionsViewModel> Problems { get; set; }
    }
}
