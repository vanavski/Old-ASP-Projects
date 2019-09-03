using NewVision.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewVision.Db.Interfaces
{
    public interface ICommentRepository
    {
        void Add(User user, Guid postId, string text);
        void Delete(Guid userId, Guid postId, string text);
        IEnumerable<Comment> GetCommentsForPost(Guid postId);
        IEnumerable<Comment> GetAll();
        Comment Get(Guid userId, Guid postId, string text);
    }
}
