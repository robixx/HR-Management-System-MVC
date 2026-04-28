using Itc.Hris.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SecurityController : Controller
    {
        private readonly IDropdown _dropdown;
        private readonly IMenu _menu;

        public SecurityController(IDropdown dropdown, IMenu menu)
        {
            _dropdown = dropdown;
            _menu = menu;
        }

        [HttpGet]
        public async Task<IActionResult> PagePermission()
        {
            ViewBag.rolelist = new SelectList(await _dropdown.getRoleAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PagePermission(int RoleId, List<int> SelectedMenus, string btnTrigger)
        {
            // Your logic for when the button is clicked
            var roles = await _dropdown.getRoleAsync();
            ViewBag.RoleList = new SelectList(roles, "Id", "Name");
            var loginUserId = HttpContext.Session.GetInt32("EmployeeId") ?? 0;
            var menulist= await _menu.SaveMenuPermission(RoleId,SelectedMenus, loginUserId, btnTrigger);
            TempData["Message"] = menulist.Message;
            TempData["Status"] = menulist.Status ? "success" : "danger";
            return View(menulist.data);
        }
    }
}
