using BlogCore.Db;
using Microsoft.AspNetCore.Mvc;
using System;
using Markdig;
using BlogCore.Web.Models;

namespace BlogCore.Web.Controllers
{
    public class PostController: Controller
    {
        private readonly PostRepository _repository;
        private readonly UserRepository _userRepository;
        private readonly CommentRepository _commentRepository;

        public PostController()
        {
            _repository = new PostRepository();
            _userRepository = new UserRepository();
            _commentRepository = new CommentRepository();
        }

        [HttpGet]
        public IActionResult ShowAllPosts()
        {
            try
            {
                var posts = _repository.GetAllPosts();
                return View("~/Views/Post/ShowPosts.cshtml", new PostsPresenter() { List = posts });
                //return View("~/Views/ShowPosts.cshtml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("~/Views/Shared/Error.cshtml", new ErrorPresenter() { Exception = e });
            }
        }

        public IActionResult AddingPost()
        {
            return View("~/Views/AddingPost.cshtml");
        }

        [HttpPost]
        public IActionResult Add()
        {
            var form = HttpContext.Request.Form;
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var text = Markdown.ToHtml(form["text"], pipeline);
            //var content = form["main-text"];
            var title = form["title"];
            try
            {
                var us = _userRepository.GetUserByLogin(Request.Cookies["userLogin"]);
                _repository.AddPost(title, text, us.Id);
                    //Helper.GetUserId(Request.Cookies["userLogin"]));
                return ShowAllPosts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("~/Views/Shared/Error.cshtml", new ErrorPresenter() { Exception = e });
            }
        }

        [HttpGet]
        public IActionResult ShowPostById(string postHeader)
        {
            postHeader = postHeader.Replace('+', ' ');
            var post = _repository.GetPostByHeader(postHeader);
            var comm = _commentRepository.Get(post.Id);
            return View("~/Views/Post/ShowPost.cshtml", new PostPresener() { Post = post, Comments = comm });
            //cshtml todo
        }

        [HttpGet]
        public IActionResult ShowPostByUserId()
        {
            try
            {
                var userId = _userRepository.GetUserByLogin(Request.Cookies["userLogin"]).Id;
                var posts = _repository.GetUsersPosts(userId);
                return View("~/Views/Post/ShowPostsByUser.cshtml", new PostsPresenter() { List = posts });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("~/Views/Shared/Error.cshtml", new ErrorPresenter() { Exception = e });
            }
        }
    }
}
