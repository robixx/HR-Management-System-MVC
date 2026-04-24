using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.ModelView
{
    public class LoginResponse
    {
        public long EmployeeeId { get; set; }
        public long UserId { get; set; }
        public string? DispalyName { get; set; }
        public string? RoleName { get; set; }
        public string? ImageName { get; set; }
        public int RoleId { get; set; }
    }
}
