using Itc.Hris.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> PagePermission(int RoleId)
        {
            // Your logic for when the button is clicked
            var roles = await _dropdown.getRoleAsync();
            ViewBag.RoleList = new SelectList(roles, "Id", "Name");

            var menulist= await _menu.SaveMenuPermission(RoleId);
           
            return View(menulist.data);
        }
    }
}
