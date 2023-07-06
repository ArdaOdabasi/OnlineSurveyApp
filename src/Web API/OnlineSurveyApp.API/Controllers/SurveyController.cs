using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Requests.SurveyRequests;
using OnlineSurveyApp.Services.SurveyService;

namespace OnlineSurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return Ok(surveys);
        }

        [HttpGet("{surveyId:int}")]
        public async Task<IActionResult> GetSurveyById(int surveyId)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(surveyId);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey(CreateNewSurveyRequest createNewSurveyRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int surveyId = await _surveyService.CreateSurveyAndReturnSurveyIdAsync(createNewSurveyRequest);
                    string url = $"https://localhost:7148/Survey/JoinSurvey?surveyId={surveyId}";
                    return Ok(url);
                }
                catch
                {
                    return StatusCode(500, "Bir Hata Oluştu!");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{surveyId}")]
        public async Task<IActionResult> UpdateSurvey(int surveyId, UpdateSurveyRequest updateSurveyRequest)
        {
            var isExists = await _surveyService.SurveyIsExistsAsync(surveyId);
            if (isExists)
            {
                if (ModelState.IsValid)
                {                 
                    try
                    {
                        await _surveyService.UpdateSurveyAsync(updateSurveyRequest);
                        return Ok("Anket Başarıyla Güncellendi!");
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

        [HttpDelete("{surveyId}")]
        public async Task<IActionResult> DeleteSurvey(int surveyId)
        {
            if (await _surveyService.SurveyIsExistsAsync(surveyId))
            {
                await _surveyService.DeleteAsync(surveyId);
                return Ok("Anket Başarıyla Silindi!");
            }
            return NotFound();
        }
    }
}
