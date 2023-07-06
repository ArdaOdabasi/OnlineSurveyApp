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
        public Task<IEnumerable<Survey>> GetActiveSurveysAsync();
        public Task<IEnumerable<Survey>> GetPassiveSurveysAsync();
        public Task<IEnumerable<Survey>> GetSurveysByConstituentAsync(int constituentId);
        public Task<IEnumerable<Survey>> GetActiveSurveysByConstituentAsync(int constituentId);
        public Task<IEnumerable<Survey>> GetPassiveSurveysByConstituentAsync(int constituentId);
    }
}
