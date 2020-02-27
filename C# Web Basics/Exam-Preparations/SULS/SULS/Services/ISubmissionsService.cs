using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(string code, string problemId, string userId);
        string GetProblemName(string problemId);
        string GetProblemId(string SubmissionId);
        void Delete(string submissionId);
    }
}
