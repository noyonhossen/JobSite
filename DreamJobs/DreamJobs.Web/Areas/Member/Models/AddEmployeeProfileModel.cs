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
        private ISkillService _skillService;

        public AddEmployeeProfileModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
            DateOfBirth = DateTime.Now;
        }

        public AddEmployeeProfileModel(IEmployeeService employeeService,
                                        ISkillService skillService)
        {
            _employeeService = employeeService;
            _skillService = skillService;
            DateOfBirth = DateTime.Now;
        }

        public async Task AddProfileDetails(string userName)
        {
            var user = await base.GetUserAsync(userName);

            var skills = base.ConvertStringSkillsToEntitySkills(this.Skills);
            var skillList = base.ConvertStringSkillsToSkillList(this.Skills);
            var employeeSkills = new List<EmployeeSkill>();

            await _skillService.AddAsync(skills);

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

            foreach (var skill in skillList)
            {
                var skillEntity = await _skillService.GetSkillByNameAsync(skill);

                if(skillEntity != null)
                {
                    var employeeSkill = new EmployeeSkill
                    {
                        SkillId = skillEntity.Id,
                        EmployeeId = user.Id
                    };

                    employeeSkills.Add(employeeSkill);
                }
            }

            employee.EmployeeSkills = employeeSkills;
            await _employeeService.AddAsync(employee);
        }
    }
}
