using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using OnlineSurveyApp.DTOs.Responses.QuestionResponses;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;

namespace OnlineSurveyApp.Mvc.Models
{
    public class SurveyDetailViewModel
    {
        public SurveyDisplayResponse survey { get; set; }
        public IEnumerable<QuestionDisplayResponse> questions { get; set; }
        public IEnumerable<OptionDisplayResponse> options { get; set; }
    }
}
