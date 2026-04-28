using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.ModelView
{
    public class MenuPermissionDto
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public int HasPermission { get; set; } 
        public string? Icon { get; set; }
        public int ParentId { get; set; }
        public int IsMainMenu { get; set; }
        public int ViewOrder { get; set; }    
        public List<MenuPermissionDto>? Permissions { get; set; }
    }
}
