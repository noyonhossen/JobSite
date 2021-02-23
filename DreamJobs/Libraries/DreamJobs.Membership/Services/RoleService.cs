using DreamJobs.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public class RoleService : IRoleService<ApplicationUser>
    {
        private IRoleService<ApplicationUser> _roleService;

        public RoleService(IRoleService<ApplicationUser> roleService)
        {
            _roleService = roleService;
        }

        public IQueryable<ApplicationUser> Roles => _roleService.Roles;
        public ILookupNormalizer KeyNormalizer { get => _roleService.KeyNormalizer; set => _roleService.KeyNormalizer = value; }
        public IdentityErrorDescriber ErrorDescriber { get => _roleService.ErrorDescriber; set => _roleService.ErrorDescriber = value; }
        public IList<IRoleValidator<ApplicationUser>> RoleValidators => _roleService.RoleValidators;
        public ILogger Logger { get => _roleService.Logger; set => _roleService.Logger = value; }
        public bool SupportsQueryableRoles => _roleService.SupportsQueryableRoles;
        public bool SupportsRoleClaims => _roleService.SupportsRoleClaims;

        public Task<IdentityResult> AddClaimAsync(ApplicationUser role, Claim claim)
        {
            return _roleService.AddClaimAsync(role, claim);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser role)
        {
            return _roleService.CreateAsync(role);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser role)
        {
            return _roleService.DeleteAsync(role);
        }

        public void Dispose()
        {
            _roleService?.Dispose();
        }

        public Task<ApplicationUser> FindByIdAsync(string roleId)
        {
            return _roleService.FindByIdAsync(roleId);
        }

        public Task<ApplicationUser> FindByNameAsync(string roleName)
        {
            return _roleService.FindByNameAsync(roleName);
        }

        public Task<IList<Claim>> GetClaimsAsync(ApplicationUser role)
        {
            return _roleService.GetClaimsAsync(role);
        }

        public Task<string> GetRoleIdAsync(ApplicationUser role)
        {
            return _roleService.GetRoleIdAsync(role);
        }

        public Task<string> GetRoleNameAsync(ApplicationUser role)
        {
            return _roleService.GetRoleNameAsync(role);
        }

        public string NormalizeKey(string key)
        {
            return _roleService.NormalizeKey(key);
        }

        public Task<IdentityResult> RemoveClaimAsync(ApplicationUser role, Claim claim)
        {
            return _roleService.RemoveClaimAsync(role, claim);
        }

        public Task<bool> RoleExistsAsync(string roleName)
        {
            return _roleService.RoleExistsAsync(roleName);
        }

        public Task<IdentityResult> SetRoleNameAsync(ApplicationUser role, string name)
        {
            return _roleService.SetRoleNameAsync(role, name);
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser role)
        {
            return _roleService.UpdateAsync(role);
        }

        public Task UpdateNormalizedRoleNameAsync(ApplicationUser role)
        {
            return _roleService.UpdateNormalizedRoleNameAsync(role);
        }
    }
}
