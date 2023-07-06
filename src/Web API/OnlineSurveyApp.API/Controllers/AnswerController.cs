using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Requests.AnswerRequests;
using OnlineSurveyApp.DTOs.Requests.SurveyRequests;
using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.Services.AnswerService;

namespace OnlineSurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            return Ok(answers);
        }

        [HttpGet("{answerId:int}")]
        public async Task<IActionResult> GetAnswerById(int answerId)
        {
            var answer = await _answerService.GetAnswerByIdAsync(answerId);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer(CreateNewAnswerRequest createNewAnswerRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _answerService.CreateAnswerAsync(createNewAnswerRequest);
                    return Ok("Cevap Başarıyla Oluşturuldu!");
                }
                catch
                {
                    return StatusCode(500, "Bir Hata Oluştu!");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{answerId}")]
        public async Task<IActionResult> UpdateAnswer(int answerId, UpdateAnswerRequest updateAnswerRequest)
        {
            var isExists = await _answerService.AnswerIsExistsAsync(answerId);
            if (isExists)
            {
                if (ModelState.IsValid)
                {              
                    try
                    {
                        await _answerService.UpdateAnswerAsync(updateAnswerRequest);
                        return Ok("Cevap Başarıyla Güncellendi!");
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

        [HttpDelete("{answerId}")]
        public async Task<IActionResult> DeleteAnswer(int answerId)
        {
            if (await _answerService.AnswerIsExistsAsync(answerId))
            {
                await _answerService.DeleteAsync(answerId);
                return Ok("Cevap Başarıyla Silindi!");
            }
            return NotFound();
        }
    }
}
