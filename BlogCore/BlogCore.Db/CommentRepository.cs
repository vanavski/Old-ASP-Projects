using BlogCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogCore.Db
{
    public class CommentRepository
    {
        CommentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public CommentRepository()
        {
            _applicationContext = new ApplicationContext();
        }

        public Comment Add(Guid userId, Guid postId, string comment)
        {
            try
            {
                var entityEntry = _applicationContext.Comments.Add(new Comment(userId, postId, comment));
                _applicationContext.SaveChanges();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<Comment> Get(Guid postId)
        {
            var comments = _applicationContext.Comments.Where(c => c.PostId.Equals(postId));
            if (comments.Count() == 0)
            {
                return new List<Comment>();
            }
            foreach (var comment in comments)
                comment.UserLogin = _applicationContext.Users.First(u => u.Id == comment.UserId)?.Login;
            return comments;
        }

        private readonly ApplicationContext _applicationContext;
    }
}
