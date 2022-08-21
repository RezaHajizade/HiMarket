using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Models.ViewModels.User
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="پسورد و تکرار پسورد باید با یکدیگر برابر باشند")]
        public string ConfirmPassword { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
