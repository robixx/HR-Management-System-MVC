using Itc.Hris.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Itc.Hris.Application.ModelView;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private readonly IRoleService _roleService;
        public UserRoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var roles = await _roleService.GetAllAsync();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role.Status == false) return NotFound();
            return View(role.data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleSave([FromBody] RoleDto roleData)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (roleData.RoleId == 0)
            {
                var result=await _roleService.CreateAsync(roleData);
                return Json(new { status = result.Status, message = result.Message });
            }
            else
            {
                var updated = await _roleService.UpdateAsync(roleData);
                if (updated.Status == false) return Json(new { status = false, message = "Not found" });
                return Json(new { status = true, message = "Updated" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            return Json(new { status = result.Status, message = result.Message });
        }
    }
}
