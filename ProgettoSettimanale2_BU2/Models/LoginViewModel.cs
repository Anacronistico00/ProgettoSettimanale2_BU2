using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Il campo Email è obbligatorio")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Il campo Password è obbligatorio")]
        public required string Password { get; set; }
    }
}
