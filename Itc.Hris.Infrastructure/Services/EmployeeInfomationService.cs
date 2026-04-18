using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Infrastructure.Services
{
    public class EmployeeInfomationService : IUserInformation
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeInfomationService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<(string Message, bool Status, EmployeeDetailsDto user_list)> GetEmpInformationAsync(long EmployeeId)
        {
            try
            {
                var employee = await _dbcontext.VwEmployeeDetails.FirstOrDefaultAsync(e => e.employeeId == EmployeeId);
                if (employee == null)
                {
                    return ("Employee not found", false, new EmployeeDetailsDto());
                }

                var result = new EmployeeDetailsDto
                {
                    employeeId = employee.employeeId,
                    profileId = employee.profileId,
                    lineManagerId = employee.lineManagerId,
                    designationId = employee.designationId,
                    employeeTypeId = employee.employeeTypeId,
                    employeeWorkType = employee.employeeWorkType,
                    unitId = employee.unitId,
                    employeeCode = employee.employeeCode,
                    profileName = employee.profileName,
                    fullname = employee.fullname,
                    profileTypeId = employee.profileTypeId,
                    email = employee.email,
                    contactNumber = employee.contactNumber,
                    corporateNumber = employee.corporateNumber,
                    fathersName = employee.fathersName,
                    mothersName = employee.mothersName,
                    permanentAddress = employee.permanentAddress,
                    presentAddress = employee.presentAddress,
                    dateOfBirth = employee.dateOfBirth,
                    dateOfJoin = employee.dateOfJoin,
                    dateOfRelease = employee.dateOfRelease,
                    dateOfResign = employee.dateOfResign,
                    photoUrl = employee.photoUrl,
                    lineManagerName = employee.lineManagerName,
                    sex = employee.sex,
                    designation = employee.designation,
                    employeeType = employee.employeeType,
                    workType = employee.workType,
                    status = employee.status,
                    moduleRoute = employee.moduleRoute,
                    department = employee.department,
                    shiftId = employee.shiftId,
                    shiftName = employee.shiftName,
                    bioUserId = employee.bioUserId??0,
                    statusId = employee.statusId
                };

                return ("Data retrieved successfully", true, result);

            }
            catch (Exception ex)
            {
                return (ex.Message, false, new EmployeeDetailsDto());  
            }
        }

        public async Task<(string Message, bool Status, List<EmployeeDetailsDto> user_list)> GetEmployeesInformationAsync()
        {

            
            try
            {
                var employee = await _dbcontext.VwEmployeeDetails.Where(i=>i.statusId==17).AsNoTracking().
                    Select(e => new EmployeeDetailsDto
                    {
                        employeeId = e.employeeId,
                        profileId = e.profileId,
                        lineManagerId = e.lineManagerId,
                        designationId = e.designationId,
                        employeeTypeId = e.employeeTypeId,
                        employeeWorkType = e.employeeWorkType,
                        unitId = e.unitId,
                        employeeCode = e.employeeCode ?? "",
                        profileName = e.profileName ?? "",
                        fullname = e.fullname ?? "",
                        email = e.email ?? "",
                        contactNumber = e.contactNumber ?? "",
                        corporateNumber = e.corporateNumber ?? "",
                        fathersName = e.fathersName ?? "",
                        mothersName = e.mothersName ?? "",
                        permanentAddress = e.permanentAddress ?? "",
                        presentAddress = e.presentAddress ?? "",
                        dateOfBirth = e.dateOfBirth,
                        dateOfJoin = e.dateOfJoin,
                        dateOfRelease = e.dateOfRelease,
                        dateOfResign = e.dateOfResign,
                        photoUrl = e.photoUrl ?? "",
                        lineManagerName = e.lineManagerName ?? "",
                        sex = e.sex ?? "",
                        designation = e.designation ?? "",
                        employeeType = e.employeeType ?? "",
                        workType = e.workType ?? "",
                        status = e.status ?? "",
                        moduleRoute = e.moduleRoute,
                        department = e.department ?? "",
                        shiftId = e.shiftId,
                        shiftName = e.shiftName ?? "",
                        bioUserId = e.bioUserId??0,
                        statusId = e.statusId
                    }).ToListAsync();



                return ("Data retrieved successfully", true, employee);
            }
            catch (Exception ex)
            {
                return ($"Method-> {nameof(GetEmployeesInformationAsync)} and Error->{ex.Message}", false, new List<EmployeeDetailsDto>());
            }
        }
    }
}
