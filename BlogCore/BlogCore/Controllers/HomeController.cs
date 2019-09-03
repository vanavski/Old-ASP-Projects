using System.Diagnostics;
using BlogCore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorPresenter { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
