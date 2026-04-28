using Itc.Hris.Application.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.Interfaces
{
    public interface IMenu
    {
        Task<List<MenuDto>> GetMenuList(int roleId);

        Task<(string Message, bool Status, List<MenuPermissionDto> data)> SaveMenuPermission(int roleId);
    }
}
