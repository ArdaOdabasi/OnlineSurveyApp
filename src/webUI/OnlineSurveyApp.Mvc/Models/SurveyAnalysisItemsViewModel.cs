using OnlineSurveyApp.DTOs.Responses.AnswerResponses;
using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using OnlineSurveyApp.DTOs.Responses.QuestionResponses;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;

namespace OnlineSurveyApp.Mvc.Models
{
    public class SurveyAnalysisItemsViewModel
    {
        public SurveyDisplayResponse survey { get; set; }
        public IEnumerable<QuestionDisplayResponse> questions { get; set; }
        public List<OptionDisplayResponse> options  { get; set; }
        public IEnumerable<AnswerDisplayResponse> answers { get; set; }
    }
}
