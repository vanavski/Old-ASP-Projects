﻿using NewVision.Core;
using NewVision.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewVision.Db.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;

        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(User user, Guid postId, string text)
        {
            _context.Comments.Add(new Comment(user.Id, postId, text) { UserLogin = user.Login });
            _context.SaveChanges();
        }

        public void Delete(Guid userId, Guid postId, string text)
        {
            var commentForDeleting =
                _context.Comments.First(c => c.UserId == userId && c.PostId == postId && c.Text == text);
            _context.Comments.Remove(commentForDeleting);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll() =>
            _context.Comments.AsEnumerable();


        public IEnumerable<Comment> GetCommentsForPost(Guid postId)
        {
            var comments = _context.Comments.Where(c => c.PostId.Equals(postId));
            foreach (var comment in comments)
                comment.UserLogin = _context.Users.First(u => u.Id == comment.UserId)?.Login;
            return comments;
        }

        public Comment Get(Guid userId, Guid postId, string text)
        {
            return _context.Comments.FirstOrDefault(c => c.Text == text && c.PostId == postId && c.UserId == userId) ??
                   throw new ArgumentException();
        }
    }
}
