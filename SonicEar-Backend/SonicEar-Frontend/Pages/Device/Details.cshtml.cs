using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SonicEar_Frontend.Pages.Device
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
