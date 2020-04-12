using System.ComponentModel.DataAnnotations;

namespace TecLibras.Services.Api.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}