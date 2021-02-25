using Autofac;
using DreamJobs.Membership.Constants;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models.Account
{
    public class SignUpCompanyModel : BaseModel
    {
        public string ReturnUrl { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public List<AuthenticationScheme> ExternalLogins { get; internal set; }
        public string Role { get; set; }
        public List<SelectListItem> Roles { get; set; }


        private readonly ISignInService<ApplicationUser> _signInService;

        public SignUpCompanyModel()
        {
            _signInService = Startup.AutofacContainer.Resolve<ISignInService<ApplicationUser>>();
        }

        public SignUpCompanyModel(ISignInService<ApplicationUser> signInService,
            IUserService<ApplicationUser> userService)
            : base(userService)
        {
            _signInService = signInService;
        }

        private ApplicationUser PoplulateUserAsync()
        {
            var user = new ApplicationUser()
            {
                Email = Email,
                UserName = Email
            };

            return user;
        }

        public async Task<(IdentityResult, ApplicationUser)> CreateUserAsync()
        {
            var user = PoplulateUserAsync();
            var result = await _userService.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                try
                {
                    await _userService.AddClaimAsync(user, new Claim(MembershipClaims.CompanyClaimType, MembershipClaims.CompanyClaimValue));
                    await _signInService.SignInAsync(user, isPersistent: false);
                }
                catch
                {
                    await _userService.DeleteAsync(user);

                    return (result, null);
                }

                return (result, user);
            }
            else
            {
                throw new InvalidOperationException("Error in creation of User");
            }

        }

        public async Task GetExternalLoginProviderAsync()
        {
            ExternalLogins = (await _signInService.GetExternalAuthenticationSchemesAsync()).ToList();
        }
    }
}
