using DreamJobs.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public class UserService : IUserService<ApplicationUser>
    {
        private readonly UserManager _userManager;

        public UserService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public IPasswordHasher<ApplicationUser> PasswordHasher { get => _userManager.PasswordHasher; set => _userManager.PasswordHasher = value; }

        public IList<IUserValidator<ApplicationUser>> UserValidators => _userManager.UserValidators;

        public IList<IPasswordValidator<ApplicationUser>> PasswordValidators => _userManager.PasswordValidators;

        public ILookupNormalizer KeyNormalizer { get => _userManager.KeyNormalizer; set => _userManager.KeyNormalizer = value; }

        public IdentityErrorDescriber ErrorDescriber { get => _userManager.ErrorDescriber; set => _userManager.ErrorDescriber = value; }

        public IdentityOptions Options { get => _userManager.Options; set => _userManager.Options = value; }

        public bool SupportsUserAuthenticationTokens => _userManager.SupportsUserAuthenticationTokens;

        public bool SupportsUserAuthenticatorKey => _userManager.SupportsUserAuthenticatorKey;

        public bool SupportsUserTwoFactorRecoveryCodes => _userManager.SupportsUserTwoFactorRecoveryCodes;

        public bool SupportsUserPassword => _userManager.SupportsUserPassword;

        public ILogger Logger { get => _userManager.Logger; set => _userManager.Logger = value; }

        public bool SupportsUserSecurityStamp => _userManager.SupportsUserSecurityStamp;

        public bool SupportsUserRole => _userManager.SupportsUserRole;

        public bool SupportsUserLogin => _userManager.SupportsUserLogin;

        public bool SupportsUserEmail => _userManager.SupportsUserEmail;

        public bool SupportsUserPhoneNumber => _userManager.SupportsUserPhoneNumber;

        public bool SupportsUserClaim => _userManager.SupportsUserClaim;

        public bool SupportsUserLockout => _userManager.SupportsUserLockout;

        public bool SupportsUserTwoFactor => _userManager.SupportsUserTwoFactor;

        public bool SupportsQueryableUsers => _userManager.SupportsQueryableUsers;

        public IQueryable<ApplicationUser> Users => _userManager.Users;

        public Task<IdentityResult> AccessFailedAsync(ApplicationUser user)
        {
            return _userManager.AccessFailedAsync(user);
        }

        public Task<IdentityResult> AddClaimAsync(ApplicationUser user, Claim claim)
        {
            return _userManager.AddClaimAsync(user, claim);
        }

        public Task<IdentityResult> AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims)
        {
            return _userManager.AddClaimsAsync(user, claims);
        }

        public Task<IdentityResult> AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            return _userManager.AddLoginAsync(user, login);
        }

        public Task<IdentityResult> AddPasswordAsync(ApplicationUser user, string password)
        {
            return _userManager.AddPasswordAsync(user, password);
        }

        public Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }

        public Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return _userManager.AddToRolesAsync(user, roles);
        }

        public Task<IdentityResult> ChangeEmailAsync(ApplicationUser user, string newEmail, string token)
        {
            return _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public Task<IdentityResult> ChangePhoneNumberAsync(ApplicationUser user, string phoneNumber, string token)
        {
            return _userManager.ChangePhoneNumberAsync(user, phoneNumber, token);
        }

        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }

        public Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            return _userManager.ConfirmEmailAsync(user, token);
        }

        public Task<int> CountRecoveryCodesAsync(ApplicationUser user)
        {
            return _userManager.CountRecoveryCodesAsync(user);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            return _userManager.CreateAsync(user);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<byte[]> CreateSecurityTokenAsync(ApplicationUser user)
        {
            return _userManager.CreateSecurityTokenAsync(user);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            return _userManager.DeleteAsync(user);
        }

        public void Dispose()
        {
            _userManager?.Dispose();
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return _userManager.FindByLoginAsync(loginProvider, providerKey);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public Task<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail)
        {
            return _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        }

        public Task<string> GenerateChangePhoneNumberTokenAsync(ApplicationUser user, string phoneNumber)
        {
            return _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
        }

        public Task<string> GenerateConcurrencyStampAsync(ApplicationUser user)
        {
            return _userManager.GenerateConcurrencyStampAsync(user);
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public string GenerateNewAuthenticatorKey()
        {
            return _userManager.GenerateNewAuthenticatorKey();
        }

        public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number)
        {
            return _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        }

        public Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<string> GenerateTwoFactorTokenAsync(ApplicationUser user, string tokenProvider)
        {
            return _userManager.GenerateTwoFactorTokenAsync(user, tokenProvider);
        }

        public Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose)
        {
            return _userManager.GenerateUserTokenAsync(user, tokenProvider, purpose);
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            return _userManager.GetAccessFailedCountAsync(user);
        }

        public Task<string> GetAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName)
        {
            return _userManager.GetAuthenticationTokenAsync(user, loginProvider, tokenName);
        }

        public Task<string> GetAuthenticatorKeyAsync(ApplicationUser user)
        {
            return _userManager.GetAuthenticatorKeyAsync(user);
        }

        public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            return _userManager.GetClaimsAsync(user);
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return _userManager.GetEmailAsync(user);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return _userManager.GetLockoutEnabledAsync(user);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user)
        {
            return _userManager.GetLockoutEndDateAsync(user);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            return _userManager.GetLoginsAsync(user);
        }

        public Task<string> GetPhoneNumberAsync(ApplicationUser user)
        {
            return _userManager.GetPhoneNumberAsync(user);
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user);
        }

        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            return _userManager.GetSecurityStampAsync(user);
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return _userManager.GetTwoFactorEnabledAsync(user);
        }

        public Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal);
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            return _userManager.GetUserId(principal);
        }

        public Task<string> GetUserIdAsync(ApplicationUser user)
        {
            return _userManager.GetUserIdAsync(user);
        }

        public string GetUserName(ClaimsPrincipal principal)
        {
            return _userManager.GetUserName(principal);
        }

        public Task<string> GetUserNameAsync(ApplicationUser user)
        {
            return _userManager.GetUserNameAsync(user);
        }

        public Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim)
        {
            return _userManager.GetUsersForClaimAsync(claim);
        }

        public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName)
        {
            return _userManager.GetUsersInRoleAsync(roleName);
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(ApplicationUser user)
        {
            return _userManager.GetValidTwoFactorProvidersAsync(user);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return _userManager.HasPasswordAsync(user);
        }

        public Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            return _userManager.IsEmailConfirmedAsync(user);
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string role)
        {
            return _userManager.IsInRoleAsync(user, role);
        }

        public Task<bool> IsLockedOutAsync(ApplicationUser user)
        {
            return _userManager.IsLockedOutAsync(user);
        }

        public Task<bool> IsPhoneNumberConfirmedAsync(ApplicationUser user)
        {
            return _userManager.IsPhoneNumberConfirmedAsync(user);
        }

        public string NormalizeEmail(string email)
        {
            return _userManager.NormalizeEmail(email);
        }

        public string NormalizeName(string name)
        {
            return _userManager.NormalizeName(name);
        }

        public Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code)
        {
            return _userManager.RedeemTwoFactorRecoveryCodeAsync(user, code);
        }

        public void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<ApplicationUser> provider)
        {
            _userManager.RegisterTokenProvider(providerName, provider);
        }

        public Task<IdentityResult> RemoveAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName)
        {
            return _userManager.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);
        }

        public Task<IdentityResult> RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            return _userManager.RemoveClaimAsync(user, claim);
        }

        public Task<IdentityResult> RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims)
        {
            return _userManager.RemoveClaimsAsync(user, claims);
        }

        public Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role)
        {
            return _userManager.RemoveFromRoleAsync(user, role);
        }

        public Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return _userManager.RemoveFromRolesAsync(user, roles);
        }

        public Task<IdentityResult> RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey)
        {
            return _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
        }

        public Task<IdentityResult> RemovePasswordAsync(ApplicationUser user)
        {
            return _userManager.RemovePasswordAsync(user);
        }

        public Task<IdentityResult> ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim)
        {
            return _userManager.ReplaceClaimAsync(user, claim, newClaim);
        }

        public Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user)
        {
            return _userManager.ResetAccessFailedCountAsync(user);
        }

        public Task<IdentityResult> ResetAuthenticatorKeyAsync(ApplicationUser user)
        {
            return _userManager.ResetAuthenticatorKeyAsync(user);
        }

        public Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            return _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public Task<IdentityResult> SetAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName, string tokenValue)
        {
            return _userManager.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);
        }

        public Task<IdentityResult> SetEmailAsync(ApplicationUser user, string email)
        {
            return _userManager.SetEmailAsync(user, email);
        }

        public Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            return _userManager.SetLockoutEnabledAsync(user, enabled);
        }

        public Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd)
        {
            return _userManager.SetLockoutEndDateAsync(user, lockoutEnd);
        }

        public Task<IdentityResult> SetPhoneNumberAsync(ApplicationUser user, string phoneNumber)
        {
            return _userManager.SetPhoneNumberAsync(user, phoneNumber);
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            return _userManager.SetTwoFactorEnabledAsync(user, enabled);
        }

        public Task<IdentityResult> SetUserNameAsync(ApplicationUser user, string userName)
        {
            return _userManager.SetUserNameAsync(user, userName);
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
            return _userManager.UpdateAsync(user);
        }

        public Task UpdateNormalizedEmailAsync(ApplicationUser user)
        {
            return _userManager.UpdateNormalizedEmailAsync(user);
        }

        public Task UpdateNormalizedUserNameAsync(ApplicationUser user)
        {
            return _userManager.UpdateNormalizedUserNameAsync(user);
        }

        public Task<IdentityResult> UpdateSecurityStampAsync(ApplicationUser user)
        {
            return _userManager.UpdateSecurityStampAsync(user);
        }

        public Task<bool> VerifyChangePhoneNumberTokenAsync(ApplicationUser user, string token, string phoneNumber)
        {
            return _userManager.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);
        }

        public Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token)
        {
            return _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        }

        public Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token)
        {
            return _userManager.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
        }

        public async Task<ApplicationUser> FindByColumnNameAsync(Expression<Func<ApplicationUser, bool>> columnName)
        {
            return await _userManager.FindByColumnNameAsync(columnName);
        }
    }
}
