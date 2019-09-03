using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCoreWeb.Models
{
    public class LoginPresenter : PageModel
    {
        public string PasswordWrong { get; set; } = "";
    }
}