using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    [Table("app_RoleMenuPermission")]
    public class AppRoleMenuPermission
    {
        [Key]
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? MenuId { get; set; }
        public int? IsActive { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
