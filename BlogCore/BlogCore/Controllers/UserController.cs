using BlogCore.Core.Entities;
using BlogCore.Db;
using BlogCore.Web.Models;
using BlogCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogCore.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _repository;

        public UserController()
        {
            _repository = new UserRepository();
        }

        private void AddUser(string login, string password)
        {
            _repository.AddUser(login, password);
        }

        private bool CheckUser(string login)
        {
            return _repository.CheckUser(login);
        }

        private bool CheckPassword(string login, string password)
        {
            return _repository.CheckPassword(login, password);
        }

        private User GetUserByLogin(string login)
        {
            return _repository.GetUserByLogin(login);
        }

        private User GetUserById(Guid id)
        {
            return _repository.GetUserById(id);
        }

        [HttpPost]
        public IActionResult Login()
        {
            var form = HttpContext.Request.Form;
            var login = form["login"];
            var password = form["password"];
            if (CheckUser(login))
            {
                if (!CheckPassword(login, password))
                    return View("~/Views/Login.cshtml", new LoginPresenter() { PasswordWrong = "1234567" });
                else
                {
                    Response.Cookies.Append("userLogin", login);
                    return Redirect("/Post/ShowAllPosts");
                }
            }
            return View("~/Views/Login.cshtml", new LoginPresenter() { PasswordWrong = "1234567" });
        }

        [HttpPost]
        public IActionResult Signup()
        {
            var form = HttpContext.Request.Form;
            var login = form["newLogin"];
            var password = form["newPassword"];

            if (!CheckUser(login))
                AddUser(login, password);
            else
                return View("~/Views/Login.cshtml", new LoginPresenter() { PasswordWrong = "1234567" });

            Response.Cookies.Append("userLogin", login);
            return Redirect("/Post/ShowAllPosts");
            //return View("~/Views/ShowPosts.cshtml", _repository.GetUserByLogin(login));
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("userLogin");
            return View("~/Views/Login.cshtml", new LoginPresenter() { PasswordWrong = "logged out" });
        }
    }
}
