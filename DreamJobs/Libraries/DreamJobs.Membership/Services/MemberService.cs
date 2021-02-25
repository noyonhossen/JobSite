using DreamJobs.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUserService<ApplicationUser> _userService;

        public MemberService(IUserService<ApplicationUser> userService)
        {
            _userService = userService;
        }

        public async Task<(bool isUserInfoUpdated, string errors)> UpdateUserInformationFromRegistrationFormDataAsync(ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User can not be null");
            }

            var result = await _userService.UpdateAsync(user);

            if (result.Succeeded)
            {
                return (true, string.Empty);
            }
            else
            {
                var errors = string.Join("", result.Errors.Select(x => $"{x.Code}:{x.Description} "));

                return (false, errors);
            }
        }
    }
}
