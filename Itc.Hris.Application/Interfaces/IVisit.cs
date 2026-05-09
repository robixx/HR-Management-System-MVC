using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Application.Interfaces
{
    public interface IVisit
    {
        Task<(string Message, bool Status)> AddressBook();
    }
}
