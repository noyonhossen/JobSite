using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Member.Models
{
    public class ViewEmployeeProfileModel : BaseModel
    {
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Skills { get; set; }

        private IEmployeeService _employeeService;

        public ViewEmployeeProfileModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }

        public ViewEmployeeProfileModel(IEmployeeService employeeService)
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
            Skills = employee.Skills;
        }
    }
}
