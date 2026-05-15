using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LeaveApplicationController : Controller
    {

        [HttpGet]
        public IActionResult LeaveCreate()
        {
            return View();
        }


        [HttpGet]
        public IActionResult LeaveRecommendation()
        {
            return View();
        }
    }
}
