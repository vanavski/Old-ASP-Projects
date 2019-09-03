using BlogCore.Core.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BlogCore.Web.Models
{
    public class PostsPresenter: PageModel
    {
        public IEnumerable<Post> List { get; set; }
    }
}
