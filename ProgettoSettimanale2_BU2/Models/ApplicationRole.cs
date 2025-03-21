using Microsoft.AspNetCore.Identity;

namespace ProgettoSettimanale2_BU2.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

    }
}
