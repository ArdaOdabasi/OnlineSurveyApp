using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.QuestionRepository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task<IEnumerable<Question>> GetQuestionsBySurveyAsync(int surveyId);
    }
}
