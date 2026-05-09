using Itc.Hris.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Infrastructure.Services
{
    public class VisitService : IVisit
    {
        public async Task<(string Message, bool Status)> AddressBook()
        {
            // Implementation for AddressBook method
            return ("AddressBook method not implemented", false);
        }
    }
}
