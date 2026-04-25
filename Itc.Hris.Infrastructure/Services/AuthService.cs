using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Infrastructure.Services
{
    public class AuthService : IAuth
    {

        private readonly ApplicationDbContext _dbcontext;
        public AuthService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<(string Message, bool Status, LoginResponse list)> LoginAsync(LoginViewModel model)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter("@loginName", model.LoginName),
                     new SqlParameter("@password", model.Password),
                };                           

                var result= await _dbcontext.LoginResponse.FromSqlRaw("EXEC V2_usp_check_user_login @loginName, @password", parameters).ToListAsync();

                if (result[0]?.UserId > 0)
                {
                   
                    return ("Login Successfully", true, result[0] ?? new LoginResponse());
                }
                return ("User Name and Password InValid", false, new LoginResponse());


            }
            catch (Exception ex)
            {
                return ($"Error : {ex.Message}", false, new LoginResponse());
            }
        }
    }
}
