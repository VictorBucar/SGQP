using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGQP.WebMVC.Models;
using System.Diagnostics;

namespace SGQP.WebMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
