using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewVision.Core;
using NewVision.Domain;
using NewVision.Web.Filter;

namespace NewVision.Web.Controllers
{
    [Authorize]
    [InternalErrorFilter]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserDomainService _userService;
        private readonly TokenService _tokenService;

        public UserController(UserDomainService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Add(User user)
        {
            _userService.Add(user.Login, user.Password, user.Role);
            return Ok();
        }

        [HttpPost]
        public IActionResult ChangeRole(string userLogin, Roles newRole)
        {
            _userService.ChangeRole(userLogin, newRole);
            return Ok(new { token = $"Bearer {_tokenService.GetToken(userLogin)}" });
        }

        [HttpGet]
        public IActionResult ContainsUser([FromQuery] string login)
        {
            var response = _userService.ContainUser(login);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Check(User user)
        {
            var response = _userService.CheckPassword(user.Login, user.Password);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string login)
        {
            var user = _userService.Get(login);
            return Ok(user);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Delete(string login)
        {
            var user = _userService.Get(login);
            _userService.Delete(user);
            return Ok();
        }
    }
}
