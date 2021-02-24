using DreamJobs.Membership.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Security
{
    public class InternalUserRequirementHandler : AuthorizationHandler<InternalUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InternalUserRequirement requirement)
        {
            if (context.User.HasClaim(x => x.Type == MembershipClaims.AdminClaimType && x.Value == MembershipClaims.AdminClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
