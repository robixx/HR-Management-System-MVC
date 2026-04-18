using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    [Table("app_RolePermission")]
    public class AppRolePermission
    {
        [Key]
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public long EmployeeId { get; set; }

        public int? IsActive { get; set; }
    }
}
