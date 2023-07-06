using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.SurveyRepository
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        public Task<IEnumerable<Survey>> GetSurveysByConstituentAsync(int constituentId);
    }
}
