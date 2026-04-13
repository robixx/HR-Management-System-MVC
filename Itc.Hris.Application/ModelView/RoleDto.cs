using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.ModelView
{
    public class RoleDto
    {
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        public string? Description { get; set; }

        public int? IsActive { get; set; }
    }
}
