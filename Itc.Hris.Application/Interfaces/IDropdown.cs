using Itc.Hris.Application.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.Interfaces
{
    public interface IDropdown
    {
        Task<List<DropDownDto>> getUserAsync();
        Task<List<DropDownDto>> getRoleAsync();
    }
}
