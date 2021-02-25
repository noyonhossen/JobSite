using DreamJobs.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public interface IMemberService
    {
        Task<(bool isUserInfoUpdated, string errors)> UpdateUserInformationFromRegistrationFormDataAsync(ApplicationUser user);
    }
}
