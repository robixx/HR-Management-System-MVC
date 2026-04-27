using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
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
    }
}
