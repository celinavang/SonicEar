using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SonicEar_Frontend.Pages.Measurement
{
    [Authorize]
    public class measurementsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
