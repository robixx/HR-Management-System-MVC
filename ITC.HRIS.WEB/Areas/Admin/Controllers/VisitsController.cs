using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VisitsController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> AddressBook()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> HRHandBook()
        {
            return View();
        }
    }
}
