using BlogCore.Core.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BlogCore.Web.Models
{
    public class PostPresener: PageModel
    {
        public PostPresener()
        {
        }

        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
