using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string code, string problemId, string userId)
        {
            int problemPoints = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            Submission submission = new Submission()
            {
                Code = code,
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId,
                AchivedResult = random.Next(0, problemPoints + 1)
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string submissionId)
        {
            var submission = this.db.Submissions.FirstOrDefault(x => x.Id == submissionId);

            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }

        public string GetProblemId(string SubmissionId)
        {
            string problemId = this.db.Problems
                .Where(x => x.Submissions.Any(s => s.Id == SubmissionId))
                .Select(x => x.Id)
                .FirstOrDefault();

            return problemId;
        }

        public string GetProblemName(string problemId)
        {
            string problemName = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Name)
                .FirstOrDefault();

            return problemName;
        }
    }
}
