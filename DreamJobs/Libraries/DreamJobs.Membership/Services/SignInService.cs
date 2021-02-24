using DreamJobs.Membership.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamJobs.Membership.Services
{
    public class SignInService : ISignInService<ApplicationUser>
    {
        private SignInManager<ApplicationUser> _signInManager;
        public SignInService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public ILogger Logger { get => _signInManager.Logger; set => _signInManager.Logger = value; }
        public HttpContext Context { get => _signInManager.Context; set => _signInManager.Context = value; }
        public IUserClaimsPrincipalFactory<ApplicationUser> ClaimsFactory { get => _signInManager.ClaimsFactory; set => _signInManager.ClaimsFactory = value; }
        public IdentityOptions Options { get => _signInManager.Options; set => _signInManager.Options = value; }
        public UserManager<ApplicationUser> UserManager { get => _signInManager.UserManager; set => _signInManager.UserManager = value; }

        public Task<bool> CanSignInAsync(ApplicationUser user)
        {
            return _signInManager.CanSignInAsync(user);
        }

        public Task<SignInResult> CheckPasswordSignInAsync(ApplicationUser user, string password, bool lockoutOnFailure)
        {
            return _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userId);
        }

        public Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user)
        {
            return _signInManager.CreateUserPrincipalAsync(user);
        }

        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
        {
            return _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
        }

        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
        {
            return _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
        }

        public Task ForgetTwoFactorClientAsync()
        {
            return _signInManager.ForgetTwoFactorClientAsync();
        }

        public Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            return _signInManager.GetExternalAuthenticationSchemesAsync();
        }

        public Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
        {
            return _signInManager.GetExternalLoginInfoAsync(expectedXsrf);
        }

        public Task<ApplicationUser> GetTwoFactorAuthenticationUserAsync()
        {
            return _signInManager.GetTwoFactorAuthenticationUserAsync();
        }

        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            return _signInManager.IsSignedIn(principal);
        }

        public Task<bool> IsTwoFactorClientRememberedAsync(ApplicationUser user)
        {
            return _signInManager.IsTwoFactorClientRememberedAsync(user);
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public Task<SignInResult> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }

        public Task RefreshSignInAsync(ApplicationUser user)
        {
            return _signInManager.RefreshSignInAsync(user);
        }

        public Task RememberTwoFactorClientAsync(ApplicationUser user)
        {
            return _signInManager.RememberTwoFactorClientAsync(user);
        }

        public Task SignInAsync(ApplicationUser user, bool isPersistent, string authenticationMethod = null)
        {
            return _signInManager.SignInAsync(user, isPersistent, authenticationMethod);
        }

        public Task SignInAsync(ApplicationUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
        {
            return _signInManager.SignInAsync(user, authenticationProperties, authenticationMethod);
        }

        public Task SignInWithClaimsAsync(ApplicationUser user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> additionalClaims)
        {
            return _signInManager.SignInWithClaimsAsync(user, authenticationProperties, additionalClaims);
        }

        public Task SignInWithClaimsAsync(ApplicationUser user, bool isPersistent, IEnumerable<Claim> additionalClaims)
        {
            return _signInManager.SignInWithClaimsAsync(user, isPersistent, additionalClaims);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient)
        {
            return _signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
        }

        public Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode)
        {
            return _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);
        }

        public Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient)
        {
            return _signInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);
        }

        public Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin)
        {
            return _signInManager.UpdateExternalAuthenticationTokensAsync(externalLogin);
        }

        public Task<ApplicationUser> ValidateSecurityStampAsync(ClaimsPrincipal principal)
        {
            return _signInManager.ValidateSecurityStampAsync(principal);
        }

        public Task<bool> ValidateSecurityStampAsync(ApplicationUser user, string securityStamp)
        {
            return _signInManager.ValidateSecurityStampAsync(user, securityStamp);
        }

        public Task<ApplicationUser> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal principal)
        {
            return _signInManager.ValidateTwoFactorSecurityStampAsync(principal);
        }
    }
}
