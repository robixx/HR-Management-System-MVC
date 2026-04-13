using Itc.Hris.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itc.Hris.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<Role?> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }
}
