using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SonicEar_Backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [DisplayName("Fornavn")]
        [Required(ErrorMessage = "Fornavn skal udfyldes.")]
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
