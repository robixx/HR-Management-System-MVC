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
    public class LeaveApplyService : ILeaveApply
    {

        private readonly  ApplicationDbContext  _dbcontext;

        public LeaveApplyService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       
    }
}
