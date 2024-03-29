﻿using NewVision.Core;
using NewVision.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewVision.Db.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(string title, Genre genre, string performer, string videoUrl, string fileLink)
        {
            if (_context.Posts.Any(p => p.Title == title))
                throw new ArgumentException("Name already exists!");
            _context.Posts.Add(new Post(title, genre, performer, videoUrl, fileLink));
            _context.SaveChanges();
        }

        public bool Contains(string header) => _context.Posts.Any(p => p.Title.Equals(header));

        public void Delete(Post post)
        {
            var postForDeleting = _context.Posts.First(p => p.Id.Equals(post.Id));
            _context.Posts.Remove(postForDeleting);
            _context.SaveChanges();
        }

        public Post Get(string title) => _context.Posts.FirstOrDefault(p => p.Title.Equals(title)) ??
                                         throw new ArgumentException($"No post with {title}");

        public Post Get(Guid postId) => _context.Posts.FirstOrDefault(p => p.Id.Equals(postId)) ??
                                        throw new ArgumentException($"No post with this postId!");

        public Post[] GetAllPosts() => _context.Posts.ToArray();

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
