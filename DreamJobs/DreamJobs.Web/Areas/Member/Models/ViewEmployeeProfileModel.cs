using Autofac;
using DreamJobs.Framework.Entities;
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
        public List<Skill> Skills{ get; set; }
        public IList<EmployeeSkill> SkillsList{ get; set; }

        private IEmployeeService _employeeService;
        private ISkillService _skillService;

        public ViewEmployeeProfileModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public ViewEmployeeProfileModel(IEmployeeService employeeService,
            ISkillService skillService)
        {
            _employeeService = employeeService;
            _skillService = skillService;
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
            SkillsList = employee.EmployeeSkills;

            Skills =  await _skillService.GetEmployeeSkillsAsync(SkillsList);
        }
    }
}
