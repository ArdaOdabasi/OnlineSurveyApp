using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;
using OnlineSurveyApp.DTOs.Responses.UserResponses;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Mvc.Models;
using OnlineSurveyApp.Services.AnswerService;
using OnlineSurveyApp.Services.OptionService;
using OnlineSurveyApp.Services.QuestionService;
using OnlineSurveyApp.Services.SurveyService;
using OnlineSurveyApp.Services.UserService;
using System.Data;
using System.Security.Claims;

namespace OnlineSurveyApp.Mvc.Controllers
{
    [Authorize(Roles = "Admin,Anketör")]
    public class AnalysisController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        private readonly IOptionService _optionService;
        private readonly ISurveyService _surveyService;
        private readonly IUserService _userService;

        public AnalysisController(IAnswerService answerService, IQuestionService questionService, IOptionService optionService, ISurveyService surveyService, IUserService userService)
        {
            _answerService = answerService;
            _questionService = questionService;
            _optionService = optionService;
            _surveyService = surveyService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SurveyDisplayResponse> surveys = new List<SurveyDisplayResponse>();
            IList<UserDisplayResponse> users = new List<UserDisplayResponse>();

            if (User.IsInRole("Admin"))
            {
                surveys = await _surveyService.GetAllSurveysAsync();
            }

            else if (User.IsInRole("Anketör"))
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                surveys = await _surveyService.GetSurveysByConstituentAsync(Convert.ToInt32(userId));
            }
                                   
            foreach (var survey in surveys)
            {
                var user = await _userService.GetUserByIdAsync(Convert.ToInt32(survey.ConstituentId));
                users.Add(user);
            }

            var model = new SurveysAndConstituentsViewModel
            {
                surveys = surveys,
                users = users,
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string surveyId)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(Convert.ToInt32(surveyId));
            var questions = await _questionService.GetQuestionsBySurveyAsync(survey.Id);
            var answers = await _answerService.GetAnswersBySurveyAsync(survey.Id);

            List<OptionDisplayResponse> options = new List<OptionDisplayResponse>();

            foreach (var question in questions)
            {
                var option = await _optionService.GetOptionsByQuestionAsync(question.Id);
                options.AddRange(option);
            }

            var model = new SurveyAnalysisItemsViewModel
            {
                survey = survey,
                questions = questions,
                options = options,
                answers = answers
            };

            return View(model);
        }
    }
}
