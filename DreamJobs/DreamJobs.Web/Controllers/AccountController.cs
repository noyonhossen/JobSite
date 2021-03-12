using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Membership.Constants;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using DreamJobs.Web.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DreamJobs.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISignInService<ApplicationUser> _signInService;
        protected readonly IUserService<ApplicationUser> _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ISignInService<ApplicationUser> signInService,
            IUserService<ApplicationUser> userService,
            ILogger<AccountController> logger)
        {
            _signInService = signInService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Signup(string returnUrl = null)
        {
            var model = new SignUpModel
            {
                ReturnUrl = returnUrl
            };
            await model.GetExternalLoginProviderAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
            await model.GetExternalLoginProviderAsync();

            if (ModelState.IsValid)
            {

                var (result, user) = await model.CreateUserAsync();

                if (result.Succeeded && user != null)
                {
                    return RedirectToAction("AddEmployeeProfile", "EmployeeProfile", new { Area = "Member" });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SignupCompany(string returnUrl = null)
        {
            var model = new SignUpCompanyModel
            {
                ReturnUrl = returnUrl
            };
            await model.GetExternalLoginProviderAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignupCompany(SignUpCompanyModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
            await model.GetExternalLoginProviderAsync();

            if (ModelState.IsValid)
            {

                var (result, user) = await model.CreateUserAsync();

                if (result.Succeeded && user != null)
                {
                    return RedirectToAction("Index", "Dashboard", new { Area = "Company" });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Signin(string returnUrl = null)
        {
            var model = new LoginModel();
            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, model.ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            model.ExternalLogins = (await _signInService.GetExternalAuthenticationSchemesAsync()).ToList();

            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signin(LoginModel model)
        {
            model.ExternalLogins = (await _signInService.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var result = await _signInService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userService.FindByEmailAsync(model.Email);
                    var claims = await _userService.GetClaimsAsync(user);

                    if (claims.Where(x => x.Type == MembershipClaims.AdminClaimType).Any())
                        return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                    else if (claims.Where(x => x.Type == MembershipClaims.CompanyClaimType).Any())
                        return RedirectToAction("Index", "Dashboard", new { Area = "Company" });
                    else
                        return RedirectToAction("Index", "Home", new { Area = "Member" });
                }
                
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Provided username or password is incorrect.");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> RegistrationForm(ApplicationUser user)
        {
            if (user?.Email == null)
            {
                return RedirectToAction("Signup");
            }

            var model = new RegistrationFormModel();
            await model.LoadModelDataAsync(user);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationForm(RegistrationFormModel model)
        {
            if (ModelState.IsValid)
            {
                var (userUpdated, errors) = await model.UpdateInformation();

                if (userUpdated)
                {
                    return RedirectToAction("Index", "Home", new { Area = "Member" });
                }

                ModelState.AddModelError(string.Empty, errors);
            }

            return View(model);
        }

        public async Task<IActionResult> Signout(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            await _signInService.SignOutAsync();
            return LocalRedirect(returnUrl);
        }
    }
}
