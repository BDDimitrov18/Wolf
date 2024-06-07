using System.ComponentModel.DataAnnotations;

namespace UserManagamentService.Models.Authentication.Login
{
    public class LoginUser
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Passwords is required")]
        public string? Password { get; set; }

    }
}
