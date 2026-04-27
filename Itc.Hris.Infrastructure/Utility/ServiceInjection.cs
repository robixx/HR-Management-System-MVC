using Itc.Hris.Application.Interfaces;
using Itc.Hris.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Hris.Infrastructure.Utility
{
    public static class ServiceInjection
    {
        public static void InjectServices(this IServiceCollection services)
        {

            
            services.AddScoped<IAuth, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IDropdown, DropDownService>();
            services.AddScoped<IUserInformation, EmployeeInfomationService>();
            services.AddScoped<IMenu, MenuService>();


        }
    }
}
