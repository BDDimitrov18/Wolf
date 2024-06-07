using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace UserManagamentService.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Namer is required")]
        public string? username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string Role { get; set; }
    }
}
