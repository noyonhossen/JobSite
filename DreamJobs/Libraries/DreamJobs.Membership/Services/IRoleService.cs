using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public interface IRoleService<TRole> : IDisposable where TRole : class
    {
        IQueryable<TRole> Roles { get; }
        ILookupNormalizer KeyNormalizer { get; set; }
        IdentityErrorDescriber ErrorDescriber { get; set; }
        IList<IRoleValidator<TRole>> RoleValidators { get; }
        ILogger Logger { get; set; }
        bool SupportsQueryableRoles { get; }
        bool SupportsRoleClaims { get; }
        Task<IdentityResult> AddClaimAsync(TRole role, Claim claim);
        Task<IdentityResult> CreateAsync(TRole role);
        Task<IdentityResult> DeleteAsync(TRole role);
        Task<TRole> FindByIdAsync(string roleId);
        Task<TRole> FindByNameAsync(string roleName);
        Task<IList<Claim>> GetClaimsAsync(TRole role);
        Task<string> GetRoleIdAsync(TRole role);
        Task<string> GetRoleNameAsync(TRole role);
        string NormalizeKey(string key);
        Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityResult> SetRoleNameAsync(TRole role, string name);
        Task<IdentityResult> UpdateAsync(TRole role);
        Task UpdateNormalizedRoleNameAsync(TRole role);
    }
}
