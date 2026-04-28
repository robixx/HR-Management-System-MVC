using Microsoft.AspNetCore.Mvc;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SecurityController : Controller
    {
        public async Task<IActionResult> PagePermission()
        {
            return View();
        }
    }
}
