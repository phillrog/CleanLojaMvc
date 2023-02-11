using System.ComponentModel.DataAnnotations;

namespace CleanLojaMvc.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display( Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password don´t match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
