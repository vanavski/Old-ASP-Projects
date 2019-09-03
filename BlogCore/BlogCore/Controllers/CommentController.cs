using BlogCore.Db;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogCore.Web.Controllers
{
    public class CommentController: Controller
    {
        private readonly CommentRepository _repository;
        private readonly PostRepository _postRepository;
        private readonly UserRepository _userRepository;

        public CommentController()
        {
            _repository = new CommentRepository();
            _postRepository = new PostRepository();
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Add([FromQuery] string textarea, string input)
        {
            var userId = _userRepository.GetUserByLogin(Request.Cookies["userLogin"]).Id;
            var login = _userRepository.GetUserById(userId).Login;
            var comment = _repository.Add(userId, Guid.Parse(input), textarea) ?? throw new ArgumentException();
            comment.UserLogin = login;
            return Json(comment);
        }

        [HttpGet]
        public IActionResult Show(Guid postId)
        {
            try
            {
                var comments = _repository.Get(postId);
                return Ok(comments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}