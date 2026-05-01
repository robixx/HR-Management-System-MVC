using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
using Itc.Hris.Model.Entities;
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

        public async Task<(string Message, bool Status)> AssignRoleAsync(long EmployeeId, int roleId)
        {
            try
            {
                var existing = await _dbcontext.AppRolePermission
                    .FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);

                if (existing != null)
                {
                    // UPDATE
                    existing.RoleId = roleId;
                    existing.IsActive = 1;
                }
                else
                {
                    // INSERT
                    var model = new AppRolePermission
                    {
                        EmployeeId = EmployeeId,
                        RoleId = roleId,
                        IsActive = 1
                    };

                    _dbcontext.AppRolePermission.Add(model);
                }

                await _dbcontext.SaveChangesAsync();

                return ("Role Assign successfully", true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }

        public async Task<(string Message, bool Status, EmployeeDetailsDto user_list)> GetEmpInformationAsync(long EmployeeId)
        {
            try
            {
                var e = await _dbcontext.VwEmployeeDetails.FirstOrDefaultAsync(e => e.employeeId == EmployeeId);
                if (e == null)
                {
                    return ("Employee not found", false, new EmployeeDetailsDto());
                }

                var result = new EmployeeDetailsDto
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
                    bioUserId = e.bioUserId ?? 0,
                    statusId = e.statusId
                };

                return ("Data retrieved successfully", true, result);

            }
            catch (Exception ex)
            {
                return (ex.Message, false, new EmployeeDetailsDto());  
            }
        }

        

        public async Task<(string Message, bool Status, List<UserWiseRoleDto> user_list)> GetEmployeesInformationAsync()
        {

            
            try
            {
                var employee = await (
                     from e in _dbcontext.VwEmployeeDetails.AsNoTracking()
                     where e.statusId == 17

                     join rp in _dbcontext.AppRolePermission
                         on e.employeeId equals rp.EmployeeId into rpGroup

                     from rp in rpGroup.DefaultIfEmpty()  

                     select new UserWiseRoleDto
                     {
                         employeeId = e.employeeId,
                         unitId = e.unitId,
                         employeeCode = e.employeeCode ?? "",
                         profileName = e.profileName ?? "",
                         fullname = e.fullname ?? "",
                         email = e.email ?? "",
                         designation = e.designation ?? "",
                         department = e.department ?? "",                       
                         roleId = rp.RoleId ??0
                     }
                 ).ToListAsync();


                return ("Data retrieved successfully", true, employee);
            }
            catch (Exception ex)
            {
                return ($"Method-> {nameof(GetEmployeesInformationAsync)} and Error->{ex.Message}", false, new List<UserWiseRoleDto>());
            }
        }

        public async Task<(string Message, bool Status, List<EmployeeInformationDto> emp_list)> GetEmployeesInFoAsync()
        {
            try
            {
                var employee = await (
                     from e in _dbcontext.VwEmployeeDetails.AsNoTracking()
                     where e.statusId == 17

                     join rp in _dbcontext.AppRolePermission
                         on e.employeeId equals rp.EmployeeId into rpGroup
                     from rp in rpGroup.DefaultIfEmpty()
                      

                     join r in _dbcontext.AppRole
                        on rp.RoleId equals r.RoleId into rGroup
                     from r in rGroup.DefaultIfEmpty()

                     select new EmployeeInformationDto
                     {
                         employeeId = e.employeeId,                         
                         employeeCode = e.employeeCode ?? "",
                         profileName = e.profileName ?? "",                         
                         email = e.email ?? "",
                         designation = e.designation ?? "",
                         department = e.department ?? "",
                         roleId = rp.RoleId ?? 0,
                         RoleName = r.RoleName ?? "",
                         Status = e.statusId == 17?"Active": "Inactive"
                     }
                 ).ToListAsync();


                return ("Data retrieved successfully", true, employee);
            }
            catch (Exception ex)
            {
                return ($"Method-> {nameof(GetEmployeesInFoAsync)} and Error->{ex.Message}", false, new List<EmployeeInformationDto>());
            }
        }
    }
}
