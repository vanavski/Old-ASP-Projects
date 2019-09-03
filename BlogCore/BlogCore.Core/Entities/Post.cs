using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCore.Core.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        public Post(Guid userId, string header, string body)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Header = header;
            Body = body;
        }
    }
}
