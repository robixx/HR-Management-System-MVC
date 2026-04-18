using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    [Table("vw_employee_name")]
    public class VwEmployeeName
    {
        public long employeeId { get; set; }
        public string? fullname { get; set; }
        public long profileId { get; set; }
        public string? employeeCode { get; set; }
    }
}
