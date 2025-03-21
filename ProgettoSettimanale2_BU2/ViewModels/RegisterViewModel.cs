using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale2_BU2.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Compare("Password")]
        public required string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
