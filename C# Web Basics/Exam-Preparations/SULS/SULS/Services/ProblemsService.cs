using SULS.Models;
using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, int points)
        {
            Problem problem = new Problem()
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<AllProblemsViewModel> GetAll()
        {
            IEnumerable<AllProblemsViewModel> AllProblems = this.db.Problems
                .Select(x => new AllProblemsViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count()
                })
                .ToList();

            return AllProblems;
        }

        public ProblemDetailsViewModel GetDetails(string problemId)
        {
            ProblemDetailsViewModel problem = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => new ProblemDetailsViewModel()
                {
                    Name = x.Name,
                    Problems = x.Submissions.Select(s => new ProblemSubmissionsViewModel()
                    {
                        SubmissionId = s.Id,
                        Username = s.User.Username,
                        CreatedOn = s.CreatedOn,
                        AchievedResult = s.AchivedResult,
                        MaxPoints = x.Points
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return problem;
        }
    }
}
