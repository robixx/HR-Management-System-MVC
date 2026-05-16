using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    [Table("app_hris_leave_calender")]
    public class AppHrisLeaveCalender
    {
        [Key]
        public int CalenderId { get; set; }

        public string CalenderName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = false;

        public int InsertBy { get; set; }

        public DateTime InsertDate { get; set; }

        public int Status { get; set; } = 0;
    }
}
