using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BlogCore.Web.Models
{
    public class ErrorPresenter: PageModel
    {
        public Exception Exception { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}