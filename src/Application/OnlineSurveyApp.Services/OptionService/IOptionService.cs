using OnlineSurveyApp.DTOs.Requests.OptionRequests;
using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.OptionService
{
    public interface IOptionService
    {
        Task<IEnumerable<OptionDisplayResponse>> GetAllOptionsAsync();
        Task<OptionDisplayResponse> GetOptionByIdAsync(int optionId);
        Task CreateOptionAsync(CreateNewOptionRequest createNewOptionRequest);
        Task UpdateOptionAsync(UpdateOptionRequest updateOptionRequest);
        Task DeleteAsync(int optionId);
        Task<bool> OptionIsExistsAsync(int optionId);
        Task<IEnumerable<OptionDisplayResponse>> GetOptionsByQuestionAsync(int questionId);
    }
}
