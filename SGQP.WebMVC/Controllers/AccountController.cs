using System;
using Microsoft.AspNetCore.Mvc;
using SGQP.WebMVC.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace SGQP.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            var input = new LoginInputViewModel
            {
                Username = "",
                Password = ""
            };

            return View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputViewModel input)
        {
            //Verifications section:
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            if(!UserAuthenticated(input.Username, input.Password))
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                return View(input);
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
            return true;
        }
    }
}