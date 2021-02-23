using DreamJobs.Membership.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Security
{
    public class CompanyRequirementHandler :
          AuthorizationHandler<CompanyRequirement>
    {
        protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context,
               CompanyRequirement requirement)
        {
            if (context.User.HasClaim(x => x.Type == MembershipClaims.CompanyClaimType && x.Value == MembershipClaims.CompanyClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
