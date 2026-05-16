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
    public class DropDownService : IDropdown
    {
        private readonly ApplicationDbContext _dbcontext;
        public DropDownService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       

        public async Task<List<DropDownDto>> getRoleAsync()
        {
            try
            {
                var userlist = await _dbcontext.AppRole
                    .Where(e=>e.IsActive==1)
                    .Select(x => new DropDownDto
                    {
                        Id = x.RoleId,
                        Name = x.RoleName
                    }).ToListAsync();

                return userlist;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DropDownDto>> getUserAsync()
        {
            try
            {
                var userlist= await _dbcontext.VwEmployeeName
                    .Select(x => new DropDownDto
                    {
                        Id = x.employeeId,
                        Name = x.fullname
                    }).ToListAsync();

                return userlist;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        public async Task<List<DropDownDto>> getDepartmentAsync()
        {
            try
            {
                var departmentList = await _dbcontext.VwEmployeeDetails
                    .Where(d => d.statusId == 17)
                    .Select(d => new DropDownDto
                    {
                        Id = d.unitId,
                        Name = d.department
                    }).ToListAsync();

                return departmentList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DropdownDtos>> GetSessionDataAsync()
        {
            try
            {
                var sessionData = await _dbcontext.AppHrisLeaveCalender.Select(x => new DropdownDtos
                {
                    Id = x.CalenderId,
                    Name = x.CalenderName
                }).ToListAsync();

                return sessionData;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
