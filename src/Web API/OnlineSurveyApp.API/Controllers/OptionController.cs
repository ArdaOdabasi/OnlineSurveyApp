using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Requests.AnswerRequests;
using OnlineSurveyApp.DTOs.Requests.OptionRequests;
using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.Services.OptionService;

namespace OnlineSurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _optionService.GetAllOptionsAsync();
            return Ok(options);
        }

        [HttpGet("{optionId:int}")]
        public async Task<IActionResult> GetOptionById(int optionId)
        {
            var option = await _optionService.GetOptionByIdAsync(optionId);
            if (option == null)
            {
                return NotFound();
            }
            return Ok(option);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOption(CreateNewOptionRequest createNewOptionRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _optionService.CreateOptionAsync(createNewOptionRequest);
                    return Ok("Seçenek Başarıyla Oluşturuldu!");
                }
                catch
                {
                    return StatusCode(500, "Bir Hata Oluştu!");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{optionId}")]
        public async Task<IActionResult> UpdateOption(int optionId, UpdateOptionRequest updateOptionRequest)
        {
            var isExists = await _optionService.OptionIsExistsAsync(optionId);
            if (isExists)
            {
                if (ModelState.IsValid)
                {                 
                    try
                    {
                        await _optionService.UpdateOptionAsync(updateOptionRequest);
                        return Ok("Seçenek Başarıyla Güncellendi!");
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

        [HttpDelete("{optionId}")]
        public async Task<IActionResult> DeleteOption(int optionId)
        {
            if (await _optionService.OptionIsExistsAsync(optionId))
            {
                await _optionService.DeleteAsync(optionId);
                return Ok("Seçenek Başarıyla Silindi!");
            }
            return NotFound();
        }
    }
}
