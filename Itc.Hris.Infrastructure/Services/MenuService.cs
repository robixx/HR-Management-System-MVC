using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
using Itc.Hris.Model.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Infrastructure.Services
{
    public class MenuService : IMenu
    {

        private readonly ApplicationDbContext _dbcontext;
        public MenuService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<MenuDto>> GetMenuList(int roleId)
        {
            try
            {
                var menuList = await (from m in _dbcontext.AppMenuSetUp
                                      join rm in _dbcontext.AppRoleMenuPermission
                                      on m.MenuId equals rm.MenuId
                                      where rm.RoleId == roleId
                                            && rm.IsActive == 1
                                            && m.IsActive == 1
                                      orderby m.ViewOrder
                                      select new MenuDto
                                      {
                                          MenuId = m.MenuId,
                                          MenuName = m.MenuName,
                                          Urls = m.Urls,
                                          AreaName = m.AreaName,
                                          ControllerName = m.ControllerName,
                                          ActionName = m.ActionName,
                                          Icon = m.Icon,
                                          IsMainMenu = m.IsMainMenu,
                                          ParentId = m.ParentId,
                                          IsActive = m.IsActive,
                                          ViewOrder = m.ViewOrder,
                                          SubMenus = new List<MenuDto>()
                                      }).ToListAsync();

                // Build hierarchy
                var mainMenus = menuList
                    .Where(x => x.IsMainMenu == 1)
                    .ToList();

                foreach (var menu in mainMenus)
                {
                    menu.SubMenus = menuList
                        .Where(x => x.ParentId == menu.MenuId)
                        .ToList();
                }

                return menuList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(string Message, bool Status, List<MenuPermissionDto> data)> SaveMenuPermission(int roleId)
        {
            try
            {

                var parameters = new SqlParameter("@RoleId", roleId);                

                var result = await _dbcontext.MenuPermissionView
                    .FromSqlRaw("EXEC V2_GetMenuPermissionsByRole @RoleId", parameters)
                    .AsNoTracking()
                    .ToListAsync();

                var permissionList = result.Where (x => x.ParentId == 0)
                 .Select(x => new MenuPermissionDto
                 {
                     RoleId = x.RoleId,
                     MenuId = x.MenuId,
                     MenuName = x.MenuName,
                     HasPermission = x.HasPermission,
                     Icon = x.Icon,
                     ParentId = x.ParentId,
                     IsMainMenu = x.IsMainMenu,
                     ViewOrder = x.ViewOrder,
                     // Map sub-menu permissions
                     Permissions = result
                         .Where(sub => sub.ParentId == x.MenuId && sub.IsMainMenu != 1)
                         .Select(sub => new MenuPermissionDto
                         {
                             RoleId = sub.RoleId,
                             MenuId = sub.MenuId,
                             MenuName = sub.MenuName,
                             HasPermission = sub.HasPermission,
                             Icon = sub.Icon,
                             ParentId = sub.ParentId,
                             IsMainMenu = sub.IsMainMenu,
                             ViewOrder = sub.ViewOrder
                         })
                         .OrderBy(sub => sub.ViewOrder)
                         .ToList()
                 })
                 .OrderBy(x => x.ViewOrder)
                 .ToList();


                return ("Menu permissions retrieved successfully", true, permissionList);

            }
            catch (Exception ex)
            {
                return ($"Error : {ex.Message}", false, new List<MenuPermissionDto>());
            }
        }
    }
}
