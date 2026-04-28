using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    public class MenuPermissionView
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public int HasPermission { get; set; } // Map the 1/0 from SQL to this
        public string? Icon { get; set; }
        public int ParentId { get; set; }
        public int IsMainMenu { get; set; }
        public int ViewOrder { get; set; }
    }
}

    