using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Requests.AnswerRequests;
using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using OnlineSurveyApp.Mvc.Models;
using OnlineSurveyApp.Services.AnswerService;
using OnlineSurveyApp.Services.OptionService;
using OnlineSurveyApp.Services.QuestionService;
using OnlineSurveyApp.Services.SurveyService;
using System.Collections.Generic;

namespace OnlineSurveyApp.Mvc.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly IQuestionService _questionService;
        private readonly IOptionService _optionService;
        private readonly IAnswerService _answerService;

        public SurveyController(ISurveyService surveyService, IQuestionService questionService, IOptionService optionService, IAnswerService answerService)
        {
            _surveyService = surveyService;
            _questionService = questionService;
            _optionService = optionService;
            _answerService = answerService;
        }

        [HttpGet]
        public async Task<IActionResult> JoinSurvey(string surveyId)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(int.Parse(surveyId));
            var questions = await _questionService.GetQuestionsBySurveyAsync(int.Parse(surveyId));
            var options = await _optionService.GetAllOptionsAsync();

            var model = new SurveyDetailViewModel
            {
                survey = survey,
                questions = questions,
                options = options
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> JoinSurvey(Dictionary<int, int> scores, Dictionary<int, int> selectedOptionIds, int surveyId)
        {
            foreach (KeyValuePair<int, int> pair in selectedOptionIds)
            {
                int questionId = pair.Key;
                int optionId = pair.Value;

                await _answerService.CreateAnswerAsync(new CreateNewAnswerRequest
                {
                    SurveyId = surveyId,
                    QuestionId = questionId,
                    OptionId = optionId,
                    RedditiveId = null,
                    Evaluation = null
                });
            }

            foreach (KeyValuePair<int, int> pair in scores)
            {
                int questionId = pair.Key;
                int evaluation = pair.Value;

                await _answerService.CreateAnswerAsync(new CreateNewAnswerRequest
                {
                    SurveyId = surveyId,
                    QuestionId = questionId,
                    Evaluation = evaluation,
                    RedditiveId = null,
                    OptionId = null,
                });
            }

            return RedirectToAction("Thanking", "Survey");
        }

        public async Task<IActionResult> Thanking()
        {
            return View();
        }
    }
}
