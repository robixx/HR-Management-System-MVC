using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Model.Entities
{
    [Table("vw_employee_details")]
    public class VwEmployeeDetails
    {
        public long employeeId { get; set; }
        public long profileId { get; set; }
        public long? lineManagerId { get; set; }
        public int designationId { get; set; }
        public int employeeTypeId { get; set; }
        public int employeeWorkType { get; set; }
        public int unitId { get; set; }
        public string? employeeCode { get; set; }
        public string? profileName { get; set; }
        public string? fullname { get; set; }
        public int profileTypeId { get; set; }
        public string? email { get; set; }
        public string? contactNumber { get; set; }
        public string? corporateNumber { get; set; }
        public string? fathersName { get; set; }
        public string? mothersName { get; set; }
        public string? permanentAddress { get; set; }
        public string? presentAddress { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateOfJoin { get; set; }
        public DateTime? dateOfRelease { get; set; }
        public DateTime? dateOfResign { get; set; }
        public string? photoUrl { get; set; }
        public string? lineManagerName { get; set; }
        public string? sex { get; set; }
        public string? designation { get; set; }
        public string? employeeType { get; set; }
        public string? workType { get; set; }
        public string? status { get; set; }
        public int? moduleRoute { get; set; }
        public string? department { get; set; }
        public int? shiftId { get; set; }
        public string? shiftName { get; set; }
        public int? bioUserId { get; set; }
        public int statusId { get; set; }
    }
}
