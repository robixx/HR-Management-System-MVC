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
        Task<(string Message, bool Status, List<EmployeeDetailsDto> user_list)> GetEmployeesInformationAsync();
        Task<(string Message, bool Status, EmployeeDetailsDto user_list)> GetEmpInformationAsync( long EnployeeId);
    }
}
