using MapperViewModels.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SGQP.Domain.Interfaces.Services;
using SGQP.Domain.ValueObjects;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SGQP.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceUser _serviceUser;

        public AccountController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputViewModel input)
        {
            //Verifications section:
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!UserAuthenticated(input.Username, input.Password))
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                return View();
            }

            //Authentication section:
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, input.Username)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home", null);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account", null);
        }

        //Verifications:

        private bool UserAuthenticated(string username, string password)
        {
            bool isUserValid = false;

            var user = _serviceUser.GetUser(username);

            if(!(user == null))
            {
                Password psw = new Password();

                var salt = user.Salt;
                var hash = psw.CreateHash(password, salt);

                if (hash == user.Password)
                {
                    isUserValid = true;
                }
            }    

            return isUserValid;
        }

        [HttpPost]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUserSave(RegisterUserViewModel registerUser)
        {
            if(registerUser == null)
            {
                return View();
            }

            if (!(registerUser.Password.Equals(registerUser.PasswordConfirmation)))
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                _serviceUser.SaveUser(registerUser);
            }

            return RedirectToAction("Login", "Account", null);
        }
    }
}