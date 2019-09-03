using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCore.Core.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string CommentText { get; set; }

        public Comment(Guid userId, Guid postId, string commentText)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PostId = postId;
            CommentText = commentText;
        }
        
        [NotMapped]
        public string UserLogin { get; set; }
    }
}
