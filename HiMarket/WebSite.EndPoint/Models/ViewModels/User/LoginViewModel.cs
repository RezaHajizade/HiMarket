using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace WebSite.EndPoint.Models.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پسورد را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [Display(Name ="من را به خاطر به سپار")]
        public bool IsPersistent { get; set; }

        public string ReturnUrl { get; set; }

    }
}
