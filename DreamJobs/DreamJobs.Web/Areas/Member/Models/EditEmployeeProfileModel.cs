using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Member.Models
{
    public class EditEmployeeProfileModel : BaseModel
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

        private IEmployeeService _employeeService;

        public EditEmployeeProfileModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }

        public EditEmployeeProfileModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task LoadModelDataAsync(string username)
        {
            var user = await base.GetUserAsync(username);

            var employee = await _employeeService.GetEmployeeDetailsAsync(user.Id);

            FullName = employee.FullName;
            FatherName = employee.FatherName;
            MotherName = employee.MotherName;
            DateOfBirth = employee.DateOfBirth;
            Gender = employee.Gender;
            MobileNo = employee.MobileNo;
            PresentAddress = employee.PresentAddress;
            PermanentAddress = employee.PermanentAddress;
        }

        public async Task EditProfile(string userName)
        {
            var user = await base.GetUserAsync(userName);

            var employee = await _employeeService.GetEmployeeDetailsAsync(user.Id);

            employee.FullName = this.FullName;
            employee.FatherName = this.FatherName;
            employee.MotherName = this.MotherName;
            employee.DateOfBirth = this.DateOfBirth;
            employee.Gender = this.Gender;
            employee.MobileNo = this.MobileNo;
            employee.PresentAddress = this.PresentAddress;
            employee.PermanentAddress = this.PermanentAddress;

            await _employeeService.UpdateAsync(employee);
        }
    }
}
