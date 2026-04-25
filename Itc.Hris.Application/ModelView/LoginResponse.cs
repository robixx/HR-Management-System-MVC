using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.ModelView
{
    public class LoginResponse
    {
        public long EmployeeId { get; set; }
        public long UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? RoleName { get; set; }
        public string? ImageName { get; set; }
        public int RoleId { get; set; }
    }
}
