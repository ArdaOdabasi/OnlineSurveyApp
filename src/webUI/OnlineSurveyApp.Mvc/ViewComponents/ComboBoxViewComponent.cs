using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.Services.SurveyService;

namespace OnlineSurveyApp.Mvc.ViewComponents
{
    public class ComboBoxViewComponent : ViewComponent
    {
        private readonly ISurveyService surveyService;

        public ComboBoxViewComponent(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var surveys = await surveyService.GetAllSurveysAsync();
            return View(surveys);
        }
    }
}
