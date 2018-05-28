using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGQP.Services.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SGQP.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPost(LoginInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!IsUserAuthenticated(inputModel.Username, inputModel.Password))
            {
                ModelState.AddModelError(string.Empty, "Usuário com senha inválida");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, inputModel.Username)

            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);

            return Redirect("/");
        }

        private bool IsUserAuthenticated(string username, string password)
        {
            return true;
        }
    }
}