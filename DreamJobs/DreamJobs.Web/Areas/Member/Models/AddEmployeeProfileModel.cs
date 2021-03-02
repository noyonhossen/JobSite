using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Member.Models
{
    public class AddEmployeeProfileModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Father's Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mother's Name")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Select Your Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile NO")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please Enter Your Present Address")]
        public string PresentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Your Permanent Address")]
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Your Skills")]
        public string Skills { get; set; }

        private IEmployeeService _employeeService;

        public AddEmployeeProfileModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            DateOfBirth = DateTime.Now;
        }

        public AddEmployeeProfileModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            DateOfBirth = DateTime.Now;
        }

        public async Task AddProfileDetails(string userName)
        {
            var user = await base.GetUserAsync(userName);

            var employee = new Employee()
            {
                UserId = user.Id,
                FullName = this.FullName,
                FatherName = this.FatherName,
                MotherName = this.MotherName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                MobileNo = this.MobileNo,
                PresentAddress = this.PresentAddress,
                PermanentAddress = this.PermanentAddress,
                Skills = this.Skills
            };

            await _employeeService.AddAsync(employee);
        }
    }
}
