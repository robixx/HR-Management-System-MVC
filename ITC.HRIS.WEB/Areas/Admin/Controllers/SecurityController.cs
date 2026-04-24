using Microsoft.AspNetCore.Mvc;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
