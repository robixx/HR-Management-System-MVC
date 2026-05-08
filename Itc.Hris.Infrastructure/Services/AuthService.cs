using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



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

                var result= await _dbcontext.LoginResponse
                    .FromSqlRaw("EXEC V2_usp_check_user_login @loginName, @password", parameters)
                    .AsNoTracking()
                    .ToListAsync();

                var response = result.FirstOrDefault();

                if (response != null && response.UserId > 0)
                {
                    return ("Login Successfully", true, response);
                }

                return ("Invalid Username or Password", false, new LoginResponse());


            }
            catch (Exception ex)
            {
                return ($"Error : {ex.Message}", false, new LoginResponse());
            }
        }
    }
}
