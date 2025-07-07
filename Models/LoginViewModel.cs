using System.ComponentModel.DataAnnotations;

namespace BlzMauiApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is mandatory")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
    }
}
