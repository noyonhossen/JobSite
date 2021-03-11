using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class BaseModel
    {
        protected readonly IUserService<ApplicationUser> _userService;
        private IEmployeeService _employeeService;

        public BaseModel()
        {
            _userService = Startup.AutofacContainer.Resolve<IUserService<ApplicationUser>>();
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }

        public BaseModel(IUserService<ApplicationUser> userService)
        {
            _userService = userService;
        }
        public BaseModel(IUserService<ApplicationUser> userService, IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
        }

        public async Task<ApplicationUser> GetUserAsync(string username)
        {
            return await _userService.FindByNameAsync(username);
        }

        public async Task<IList<Claim>> GetUserClaimsAsync(string username)
        {
            var user = await GetUserAsync(username);
            var claims = await _userService.GetClaimsAsync(user);

            return claims;
        }

        public async Task<Employee> GetEmployeeAsync(string username)
        {
            var user =  await _userService.FindByNameAsync(username);
            return await _employeeService.GetEmployeeDetailsAsync(user.Id);
        }
    }
}
