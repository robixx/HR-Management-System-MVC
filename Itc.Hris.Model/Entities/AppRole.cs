using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itc.Hris.Model.Entities
{

    [Table("app_Role")]
    public class AppRole
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public int? IsActive { get; set; }
    }
}
