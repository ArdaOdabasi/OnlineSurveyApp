using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.Services.UserService;

namespace OnlineSurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateNewUserRequest createNewUserRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateUserAsync(createNewUserRequest);
                    return Ok("Kullanıcı Başarıyla Oluşturuldu!");
                }
                catch
                {
                    return StatusCode(500, "Bir Hata Oluştu!");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UpdateUserRequest updateUserRequest)
        {
            var isExists = await _userService.UserIsExistsAsync(userId);
            if (isExists)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await _userService.UpdateUserAsync(updateUserRequest);
                        return Ok("Kullanıcı Başarıyla Güncellendi!");
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (await _userService.UserIsExistsAsync(userId))
            {
                await _userService.DeleteAsync(userId);
                return Ok("Kullanıcı Başarıyla Silindi!");
            }
            return NotFound();
        }

        [HttpPost("{username}/{password}")]
        public async Task<IActionResult> ValidateUser(string username, string password)
        {
            var user = await _userService.ValidateUserAsync(username, password);

            if (user == null)
            {
                return BadRequest("Geçersiz Kullanıcı Adı Veya Şifre!");
            }

            return Ok("Kullanıcı Doğrulama Başarılı!");
        }
    }
}
