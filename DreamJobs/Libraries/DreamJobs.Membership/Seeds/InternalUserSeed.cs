using DreamJobs.Data.Seeds;
using DreamJobs.Membership.Constants;
using DreamJobs.Membership.Contexts;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Seeds
{
    public class InternalUserSeed : DataSeed
    {
        private readonly IUserService<ApplicationUser> _userService;
        private readonly ApplicationUser _adminUser;

        public InternalUserSeed(IUserService<ApplicationUser> userService, ApplicationDbContext context)
            : base(context)
        {
            _userService = userService;
            _adminUser = new ApplicationUser("admin@hstu.ac.bd", "admin@hstu.ac.bd");
        }

        public override async Task SeedAsync()
        {
            await SeedInternalUserAsync();
        }

        public async Task SeedInternalUserAsync()
        {
            IdentityResult result = null;
            var password = "admin@hstu";

            if (await _userService.FindByEmailAsync(_adminUser.Email) == null)
            {
                result = await _userService.CreateAsync(_adminUser, password);

                if (result.Succeeded)
                {
                    await _userService.AddClaimsAsync(
                        _adminUser,
                        new List<Claim>
                        {
                            new Claim(MembershipClaims.AdminClaimType,MembershipClaims.AdminClaimValue)
                        });
                }
            }
        }
    }
}
