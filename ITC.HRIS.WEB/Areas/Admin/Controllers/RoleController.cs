using Itc.Hris.Application.Interfaces;
using Itc.Hris.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
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
            return PartialView("_RoleList", roles);
        }

        public IActionResult Create()
        {
            return PartialView("_RoleCreateEdit", new Role());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null) return NotFound();
            return PartialView("_RoleCreateEdit", role);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Role role)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (role.Id == 0)
            {
                await _roleService.CreateAsync(role);
                return Json(new { status = true, message = "Created" });
            }
            else
            {
                var updated = await _roleService.UpdateAsync(role);
                if (updated == null) return Json(new { status = false, message = "Not found" });
                return Json(new { status = true, message = "Updated" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            return Json(new { status = result });
        }
    }
}
