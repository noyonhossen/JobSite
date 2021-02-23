using DreamJobs.Data;
using Microsoft.AspNetCore.Identity;
using System;

namespace DreamJobs.Membership.Entities
{
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
        public Role()
            : base()
        {
        }

        public Role(string roleName)
            : base(roleName)
        {
        }
    }
}
