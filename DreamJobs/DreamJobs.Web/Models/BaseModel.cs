using Autofac;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class BaseModel
    {
        protected readonly IUserService<ApplicationUser> _userService;

        public BaseModel()
        {
            _userService = Startup.AutofacContainer.Resolve<IUserService<ApplicationUser>>();
        }

        public BaseModel(IUserService<ApplicationUser> userService)
        {
            _userService = userService;
        }
    }
}
