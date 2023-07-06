using OnlineSurveyApp.DTOs.Responses.AnswerResponses;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;
using OnlineSurveyApp.DTOs.Responses.UserResponses;

namespace OnlineSurveyApp.Mvc.Models
{
    public class SurveysAndConstituentsViewModel
    {
        public IEnumerable<SurveyDisplayResponse> surveys { get; set; }
        public IList<UserDisplayResponse> users { get; set; }
    }
}
