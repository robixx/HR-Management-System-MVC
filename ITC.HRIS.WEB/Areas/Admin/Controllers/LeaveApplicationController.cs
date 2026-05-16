using Itc.Hris.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LeaveApplicationController : Controller
    {

        private readonly IDropdown _dropdown;

        public LeaveApplicationController(IDropdown dropdown)
        {
            _dropdown = dropdown;
        }



        [HttpGet]
        public async Task<IActionResult> LeaveCreate()
        {

            ViewBag.calendar = new SelectList(await _dropdown.GetSessionDataAsync(), "Id", "Name");

            return View();
        }


        [HttpGet]
        public IActionResult LeaveRecommendation()
        {
            return View();
        }
    }
}
