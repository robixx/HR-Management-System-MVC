using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Infrastructure.Services
{
    public class AuthService : IAuth
    {
        public Task<(string Message, bool Status, LoginResponse list)> LoginAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
