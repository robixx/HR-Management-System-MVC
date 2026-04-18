using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.ModelView
{
    public class PermissionShowDto
    {
        public List<RoleDto> RoleDtos { get; set; }=new List<RoleDto>();
        public List<UserWiseRoleDto> EmployeeDetailsDtos { get; set; }= new List<UserWiseRoleDto>();
    }
}
