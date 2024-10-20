using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            ResponseDto result = await _authService.LoginAsync(model);
            if (result != null && result.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(result.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", result.Message);
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = SD.RoleAdmin, Value=SD.RoleAdmin},
                new SelectListItem{Text = SD.RoleCustomer, Value=SD.RoleCustomer}
            };

            ViewBag.RoleList = roleList;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto model)
        {
            ResponseDto result = await _authService.RegisterUserAsync(model);
            ResponseDto assignRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(model.Role))
                {
                    model.Role = SD.RoleCustomer;
                }

                assignRole = await _authService.AssignRoleAsync(model);
                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration successful";
                    return RedirectToAction(nameof(Login));
                }

            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
            return View(model);
        }

        public IActionResult Logout()
        {
            return View();
        }

    }
}
