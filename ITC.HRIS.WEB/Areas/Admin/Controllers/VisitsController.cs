using Itc.Hris.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VisitsController : Controller
    {

        private readonly IDropdown _dropdown;

        public VisitsController(IDropdown dropdown)
        {
            _dropdown = dropdown;
        }

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
        

        [HttpGet]
        public async Task<IActionResult> EmployeeWiseApproval()
        {
            ViewBag.unitlist = new SelectList(await _dropdown.getDepartmentAsync(), "Id", "Name");
            return View();
        }
    }
}
