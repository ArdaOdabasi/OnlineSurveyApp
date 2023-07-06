using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.AnswerRepository
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        public Task<IEnumerable<Answer>> GetAnswersBySurveyAsync(int surveyId);
    }
}
