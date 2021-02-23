using DreamJobs.Membership.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Security
{
    public class MemberRequirementHandler : AuthorizationHandler<MemberRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MemberRequirement requirement)
        {
            if (context.User.HasClaim(x => x.Type == MembershipClaims.MemberClaimType && x.Value == MembershipClaims.MemberClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
