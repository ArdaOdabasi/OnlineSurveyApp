using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.OptionRepository
{
    public interface IOptionRepository : IRepository<Option>
    {
        public Task<IEnumerable<Option>> GetOptionsByQuestionAsync(int questionId);
    }
}
