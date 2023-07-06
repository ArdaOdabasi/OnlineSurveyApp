using OnlineSurveyApp.DTOs.Requests.SurveyRequests;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;
using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.SurveyService
{
    public interface ISurveyService
    {
        Task<IEnumerable<SurveyDisplayResponse>> GetAllSurveysAsync();
        Task<SurveyDisplayResponse> GetSurveyByIdAsync(int surveyId);
        Task CreateSurveyAsync(CreateNewSurveyRequest createNewSurveyRequest);
        Task<int> CreateSurveyAndReturnSurveyIdAsync(CreateNewSurveyRequest createNewSurveyRequest);
        Task UpdateSurveyAsync(UpdateSurveyRequest updateSurveyRequest);
        Task DeleteAsync(int surveyId);
        Task<bool> SurveyIsExistsAsync(int surveyId);
        Task<IEnumerable<SurveyDisplayResponse>> GetSurveysByConstituentAsync(int constituentId);
    }
}
