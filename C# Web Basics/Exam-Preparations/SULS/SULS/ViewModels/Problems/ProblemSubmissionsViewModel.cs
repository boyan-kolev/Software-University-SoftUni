using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.ViewModels.Problems
{
    public class ProblemSubmissionsViewModel
    {
        public string Username { get; set; }
        public int AchievedResult { get; set; }
        public int MaxPoints { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SubmissionId { get; set; }
    }
}
