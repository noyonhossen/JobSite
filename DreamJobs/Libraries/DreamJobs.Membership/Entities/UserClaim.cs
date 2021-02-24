using System;
using Microsoft.AspNetCore.Identity;

namespace DreamJobs.Membership.Entities
{
    public class UserClaim
        : IdentityUserClaim<Guid>
    {
        public UserClaim()
            : base()
        {

        }
    }
}
