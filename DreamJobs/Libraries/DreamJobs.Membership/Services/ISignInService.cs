using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public interface ISignInService<TUser> where TUser : class
    {
        ILogger Logger { get; set; }
        HttpContext Context { get; set; }
        IUserClaimsPrincipalFactory<TUser> ClaimsFactory { get; set; }
        IdentityOptions Options { get; set; }
        UserManager<TUser> UserManager { get; set; }
        Task<bool> CanSignInAsync(TUser user);
        Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, bool lockoutOnFailure);
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        Task ForgetTwoFactorClientAsync();
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);
        Task<TUser> GetTwoFactorAuthenticationUserAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<bool> IsTwoFactorClientRememberedAsync(TUser user);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure);
        Task RefreshSignInAsync(TUser user);
        Task RememberTwoFactorClientAsync(TUser user);
        Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null);
        Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null);
        Task SignInWithClaimsAsync(TUser user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> additionalClaims);
        Task SignInWithClaimsAsync(TUser user, bool isPersistent, IEnumerable<Claim> additionalClaims);
        Task SignOutAsync();
        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
        Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
        Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
        Task<TUser> ValidateSecurityStampAsync(ClaimsPrincipal principal);
        Task<bool> ValidateSecurityStampAsync(TUser user, string securityStamp);
        Task<TUser> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal principal);
    }
}
