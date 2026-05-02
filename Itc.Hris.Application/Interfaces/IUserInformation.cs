using Itc.Hris.Application.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.Interfaces
{
    public interface IUserInformation
    {
        Task<(string Message, bool Status, List<UserWiseRoleDto> user_list)> GetEmployeesInformationAsync();
        Task<(string Message, bool Status, List<EmployeeInformationDto> emp_list)> GetEmployeesInFoAsync();
        Task<(string Message, bool Status, EmployeeDetailsDto user_list)> GetEmpInformationAsync( long EnployeeId);
        Task<(string Message, bool Status)> AssignRoleAsync( long EmployeeId, int roleId);
        Task<(string Message, bool Status, EmployeeDetailsDto data)> EmployeeDetailsAsync(long enployeeid);
    }
}
