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
            //Checks if input is empty
            if (IsInputValid(inputModel))
            {
                ModelState.AddModelError(string.Empty, "Informe os dados do usuário");
            }

            //Checks if inputModel is Valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Check if that user exists in database
            if (!IsUserAuthenticated(inputModel.Username, inputModel.Password))
            {
                ModelState.AddModelError(string.Empty, "Usuário com senha inválida");
                return Page();
            }

            //Creates claims
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
            //Its necessary to implement database check 
            return true;
        }

        private bool IsInputValid(LoginInputModel inputModel)
        {
            if("".Equals(inputModel) || inputModel == null)
            {
                return false;
            }
            return true;
        }
    }
}