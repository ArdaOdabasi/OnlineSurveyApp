using OnlineSurveyApp.DTOs.Requests.AnswerRequests;
using OnlineSurveyApp.DTOs.Responses.AnswerResponses;
using OnlineSurveyApp.DTOs.Responses.QuestionResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.AnswerService
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerDisplayResponse>> GetAllAnswersAsync();
        Task<AnswerDisplayResponse> GetAnswerByIdAsync(int answerId);
        Task CreateAnswerAsync(CreateNewAnswerRequest createNewAnswerRequest);
        Task UpdateAnswerAsync(UpdateAnswerRequest updateAnswerRequest);
        Task DeleteAsync(int answerId);
        Task<bool> AnswerIsExistsAsync(int answerId);
        Task<IEnumerable<AnswerDisplayResponse>> GetAnswersBySurveyAsync(int surveyId);
    }
}
