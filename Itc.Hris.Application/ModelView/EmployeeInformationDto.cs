using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.ModelView
{
    public class EmployeeInformationDto
    {
        public long employeeId { get; set; }       
        public string? employeeCode { get; set; }
        public string? profileName { get; set; }        
        public string? email { get; set; }
        public string? department { get; set; }
        public string? designation { get; set; }
        public int roleId { get; set; } = 0;
        public string? RoleName { get; set; }
        public string? Status { get; set; }
    }
}
