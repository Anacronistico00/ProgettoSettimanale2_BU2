using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale2_BU2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        
        public ICollection<Prenotazione> Prenotazioni { get; set; }

        public ICollection<Cliente> Clienti { get; set; }

    }
}
