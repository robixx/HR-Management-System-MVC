using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITC.HRIS.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserRoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IDropdown _dropdown;
        private readonly IUserInformation _userInformation;
        public UserRoleController(IRoleService roleService, IDropdown dropdown, IUserInformation userInformation)
        {
            _roleService = roleService;
            _dropdown = dropdown;
            _userInformation = userInformation;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetAllAsync();           
            ViewBag.rolelist= new SelectList(await _dropdown.getRoleAsync(), "Id", "Name");
            var empinfo= await _userInformation.GetEmployeesInformationAsync();

            var result = new PermissionShowDto
            {
                RoleDtos = roles.data_list ?? new List<RoleDto>(),
                EmployeeDetailsDtos = empinfo.user_list ?? new List<UserWiseRoleDto>()
            };

            return View(result);
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

           
                var result=await _roleService.CreateAsync(roleData);
                return Json(new { status = result.Status, message = result.Message });
            
        }

        [HttpPost]
        public async Task<IActionResult> RoleDelete(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            return Json(new { status = result.Status, message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(int EmployeeId, int RoleId)
        {
            
            var result = await _userInformation.AssignRoleAsync(EmployeeId, RoleId);
            return Json(new { status = result.Status, message = result.Message });
        }
         
    }
}
