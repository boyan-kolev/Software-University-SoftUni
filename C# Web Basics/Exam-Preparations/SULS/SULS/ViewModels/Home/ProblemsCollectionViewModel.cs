using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.ViewModels.Home
{
    public class ProblemsCollectionViewModel
    {
        public ProblemsCollectionViewModel()
        {
            this.Problems = new List<AllProblemsViewModel>();
        }

        public IEnumerable<AllProblemsViewModel> Problems { get; set; }
    }
}
