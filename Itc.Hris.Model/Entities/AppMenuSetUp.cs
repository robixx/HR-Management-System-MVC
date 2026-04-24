using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    [Table("app_MenuSetUp")]
    public class AppMenuSetUp
    {
       
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public string? Urls { get; set; }
        public string? AreaName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Icon { get; set; }
        public int IsMainMenu { get; set; }
        public int ParentId { get; set; }
        public int IsActive { get; set; }
        public int ViewOrder { get; set; }
    }
}
