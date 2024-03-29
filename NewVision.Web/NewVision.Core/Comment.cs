﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewVision.Core
{
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid();
        }

        public Comment(Guid userId, Guid postId, string text)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PostId = postId;
            Text = text;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserLogin { get; set; }
        public Guid PostId { get; set; }
        public string Text { get; set; }
    }
}
