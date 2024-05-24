using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace SonicEar_Backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [DisplayName("Fornavn")]
        public string? FName { get; set; }

        [PersonalData]
        [DisplayName("Efternavn")]
        public string? LName { get; set; }
    }
}
