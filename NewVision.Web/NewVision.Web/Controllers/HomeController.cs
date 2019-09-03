using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewVision.Web.Models;

namespace NewVision.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public string AnonymousSignIn([FromServices] JwtSignInHandler tokenFactory)
        {
            var principal = new System.Security.Claims.ClaimsPrincipal(new[]
            {
                new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "Demo User")
                })
            });
            return tokenFactory.BuildJwt(principal);
        }

        public IActionResult Index()
        {
            return View("~/Views/Login.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
