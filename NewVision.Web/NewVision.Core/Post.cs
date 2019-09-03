using System;
using System.Collections.Generic;
using System.Text;

namespace NewVision.Core
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }

        public Post(string title, Genre genre, string performer, string videoUrl, string fileLink)
        {
            Id = Guid.NewGuid();
            Title = title;
            Genre = genre;
            Performer = performer;
            VideoUrl = videoUrl;
            FileLink = fileLink;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Performer { get; set; }
        public string VideoUrl { get; set; }
        public string FileLink { get; set; }
    }
}
