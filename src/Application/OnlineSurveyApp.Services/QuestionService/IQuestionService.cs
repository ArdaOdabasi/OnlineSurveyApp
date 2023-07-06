using OnlineSurveyApp.DTOs.Requests.QuestionRequests;
using OnlineSurveyApp.DTOs.Responses.QuestionResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDisplayResponse>> GetAllQuestionsAsync();
        Task<QuestionDisplayResponse> GetQuestionByIdAsync(int questionId);
        Task CreateQuestionAsync(CreateNewQuestionRequest createNewQuestionRequest);
        Task UpdateQuestionAsync(UpdateQuestionRequest updateQuestionRequest);
        Task DeleteAsync(int questionId);
        Task<bool> QuestionIsExistsAsync(int questionId);
        Task<IEnumerable<QuestionDisplayResponse>> GetQuestionsBySurveyAsync(int surveyId);
    }
}
