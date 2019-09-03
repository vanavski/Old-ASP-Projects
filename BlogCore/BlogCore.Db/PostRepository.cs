using BlogCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogCore.Db
{
    public class PostRepository
    {
        private readonly ApplicationContext _applicationContext;

        public PostRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public PostRepository()
        {
            _applicationContext = new ApplicationContext();
        }

        public void AddPost(string header, string body, Guid userId)
        {
            if (_applicationContext.Posts.Any(p => p.Header == header)) throw new ArgumentException("Name already exists!");
            _applicationContext.Posts.Add(new Post(userId, header, body));
            _applicationContext.SaveChanges();
        }

        public bool CheckPost(string header)
        {
            return _applicationContext.Posts.Any(p => p.Header.Equals(header));
        }

        public Post GetPostById(Guid postId) => _applicationContext.Posts.First(p => p.Id.Equals(postId));

        public List<Post> GetUsersPosts(Guid userId) => _applicationContext.Posts.Where(p => p.UserId.Equals(userId)).ToList();

        public List<Post> GetAllPosts() => _applicationContext.Posts.ToList();

        public Post GetPostByHeader(string header) => _applicationContext.Posts.First(p => p.Header.Equals(header));
    }
}
