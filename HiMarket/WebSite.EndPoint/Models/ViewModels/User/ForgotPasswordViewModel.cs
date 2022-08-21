using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Models.ViewModels.User
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
