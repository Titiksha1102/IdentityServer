using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppIdentityServer.Models
{
    public class RegisterViewModel
    {
        public string ReturnUrl { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Please enter a valid Email address.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and confirmation Password do not match.")]
        public string ConfirmPassword {  get; set; }
    }
}
