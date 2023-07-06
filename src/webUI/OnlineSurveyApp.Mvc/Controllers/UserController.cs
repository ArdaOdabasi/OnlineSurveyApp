using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineSurveyApp.Services.UserService;
using System.Security.Claims;
using OnlineSurveyApp.Mvc.Models;
using OnlineSurveyApp.DTOs.Requests.UserRequests;

namespace OnlineSurveyApp.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? ReturnUrlParameter)
        {
            ViewBag.ReturnUrl = ReturnUrlParameter;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? ReturnUrlParameter)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ValidateUserAsync(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Role,user.Role),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };
                    ViewBag.LastName = user.LastName;
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    if (!string.IsNullOrEmpty(ReturnUrlParameter) && Url.IsLocalUrl(ReturnUrlParameter))
                    {
                        return Redirect(ReturnUrlParameter);
                    }
                    return Redirect("/");

                }

                ModelState.AddModelError("login", "Kullanıcı Adı Veya Şifre Yanlış!");
            }

            return View();
        }

        public IActionResult SignUp(string? ReturnUrlParameter)
        {
            ViewBag.ReturnUrl = ReturnUrlParameter;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateNewUserRequest createNewUserRequest, string? ReturnUrlParameter)
        {
            ViewBag.ReturnUrl = ReturnUrlParameter;

            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(createNewUserRequest);
                return Redirect("/User/Login");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
