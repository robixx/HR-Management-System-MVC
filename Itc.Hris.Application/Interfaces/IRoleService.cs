
using Itc.Hris.Application.ModelView;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itc.Hris.Application.Interfaces
{
    public interface IRoleService
    {
        Task<(string Message, bool Status,List<RoleDto>data_list)> GetAllAsync();
        Task<(string Message, bool Status, RoleDto? data)> GetByIdAsync(int id);
        Task<(string Message, bool Status)> CreateAsync(RoleDto role);
        Task<(string Message, bool Status)> UpdateAsync(RoleDto role);
        Task<(string Message, bool Status)> DeleteAsync(int id);
        
    }
}
