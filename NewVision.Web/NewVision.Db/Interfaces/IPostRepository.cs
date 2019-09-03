using NewVision.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewVision.Db.Interfaces
{
    public interface IPostRepository
    {
        void Add(string title, Genre genre, string performer, string videoUrl, string fileLink);
        void Delete(Post post);
        bool Contains(string header);
        Post Get(string title);
        Post Get(Guid postId);
        Post[] GetAllPosts();
        void Update(Post post);
    }
}
