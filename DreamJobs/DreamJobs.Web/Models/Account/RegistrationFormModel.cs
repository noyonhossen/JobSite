using Autofac;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Enums;
using DreamJobs.Membership.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models.Account
{
    public class RegistrationFormModel : BaseModel
    {
        private readonly ISignInService<ApplicationUser> _signInService;
        private readonly IMemberService _memberService;

        public string ExternalImageUrl { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string Mobile { get; set; }

        public GenderType Gender { get; set; }

        public RegistrationFormModel()
        {
            _signInService = Startup.AutofacContainer.Resolve<ISignInService<ApplicationUser>>();
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }

        public RegistrationFormModel(IUserService<ApplicationUser> userService,
            ISignInService<ApplicationUser> signInService,
            IMemberService memberService
            ) : base(userService)
        {
            _signInService = signInService;
            _memberService = memberService;
        }

        public async Task LoadModelDataAsync(ApplicationUser user)
        {
            if (user == null)
                throw new InvalidOperationException("User was missing");

            Email = user.Email;
            await Task.CompletedTask;
        }

        public async Task<(bool isUserInfoUpdated, string errors)> UpdateInformation()
        {
            var user = await PrepareUpdatedUserInformation();

            if (user != null)
            {
                return await _memberService.UpdateUserInformationFromRegistrationFormDataAsync(user);
            }

            return (false, "Something went wrong in getting back data");
        }

        private async Task<ApplicationUser> PrepareUpdatedUserInformation()
        {
            var user = await _userService.FindByEmailAsync(Email);

            if (user == null)
                return null;

            user.Email = Email;
            user.PhoneNumber = Mobile;

            return user;
        }
    }
}
