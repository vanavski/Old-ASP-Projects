using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewVision.Core;
using NewVision.Domain;
using NewVision.Web.Filter;
using System;

namespace NewVision.Web.Controllers
{
    [AllowAnonymous]
    [InternalErrorFilter]
    [Route("[controller]/[action]")]
    public class TokenController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly UserDomainService _userService;

        public TokenController(TokenService tokenService, UserDomainService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register()
        {
            var form = HttpContext.Request.Form;
            var username = form["login"];
            var password = form["password"];
            _userService.Add(username, password, Roles.Junior);
            Ok(new { login = username, token = $"Bearer {_tokenService.GetToken(username)}" });
            return View("~/Views/Home/Index.cshtml");
        }

        //сделать проверку токена на других стр
        [HttpPost]
        public IActionResult Login()
        {
            var form = HttpContext.Request.Form;
            var username = form["login"];
            var password = form["password"];
            if (!_userService.ContainUser(username))
                throw new ArgumentException($"Cant find user {username}");//сделать обработку искл для отобр на стр

            _userService.CheckPassword(username, password);//тут тоже

            Ok(new { login = username, token = $"Bearer {_tokenService.GetToken(username)}" });
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
