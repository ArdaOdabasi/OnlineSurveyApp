using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Requests.OptionRequests;
using OnlineSurveyApp.DTOs.Requests.QuestionRequests;
using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.Services.QuestionService;

namespace OnlineSurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{questionId:int}")]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await _questionService.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateNewQuestionRequest createNewQuestionRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _questionService.CreateQuestionAsync(createNewQuestionRequest);
                    return Ok("Soru Başarıyla Oluşturuldu!");
                }
                catch
                {
                    return StatusCode(500, "Bir Hata Oluştu!");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{questionId}")]
        public async Task<IActionResult> UpdateQuestion(int questionId, UpdateQuestionRequest updateQuestionRequest)
        {
            var isExists = await _questionService.QuestionIsExistsAsync(questionId);
            if (isExists)
            {
                if (ModelState.IsValid)
                {                   
                    try
                    {
                        await _questionService.UpdateQuestionAsync(updateQuestionRequest);
                        return Ok("Soru Başarıyla Güncellendi!");
                    }
                    catch
                    {
                        return StatusCode(500, "Bir Hata Oluştu!");
                    }
                }

                return BadRequest(ModelState);
            }
            return NotFound();
        }

        [HttpDelete("{questionId}")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            if (await _questionService.QuestionIsExistsAsync(questionId))
            {
                await _questionService.DeleteAsync(questionId);
                return Ok("Soru Başarıyla Silindi!");
            }
            return NotFound();
        }
    }
}
