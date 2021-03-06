using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class BaseModel
    {
        protected readonly IUserService<ApplicationUser> _userService;
        private IEmployeeService _employeeService;

        public BaseModel()
        {
            _userService = Startup.AutofacContainer.Resolve<IUserService<ApplicationUser>>();
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }

        public BaseModel(IUserService<ApplicationUser> userService)
        {
            _userService = userService;
        }
        public BaseModel(IUserService<ApplicationUser> userService, IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
        }

        public async Task<ApplicationUser> GetUserAsync(string username)
        {
            return await _userService.FindByNameAsync(username);
        }

        public async Task<Employee> GetEmployeeAsync(string username)
        {
            var user =  await _userService.FindByNameAsync(username);
            return await _employeeService.GetEmployeeDetailsAsync(user.Id);
        }

        public (string matchedSkills,int totalSkills,int totalSkillsRequired) GetUserMatchedSkillsAsync(string skillsRequired,string skillsOfEmployee)
        {
            var matchedSkills = new StringBuilder();
            var totalMatchedSkills = 0;
            var totalSkillsRequired = 0;

            string[] requiredSkills = skillsRequired.Split(',');

            foreach (var requiredSkill in requiredSkills)
            {
                var requiredSkillTrimed = requiredSkill.Trim();
                totalSkillsRequired++;

                if (skillsOfEmployee.ToLower().Contains(requiredSkillTrimed.ToLower()))
                {
                    matchedSkills.Append(requiredSkill + ",");
                    totalMatchedSkills++;
                }
            }

            return (matchedSkills.ToString().TrimEnd(','), totalMatchedSkills, totalSkillsRequired);
        }

        public List<Skill> ConvertStringSkillsToEntitySkills(string skills)
        {
            var skillsList = new List<Skill>();

            string[] skillListSplit = skills.Split(',');

            foreach (var skill in skillListSplit)
            {
                skillsList.Add(new Skill { Name = skill.Trim().ToLower() });
            }

            return skillsList;
        }

        public List<string> ConvertStringSkillsToSkillList(string skills)
        {
            var skillsList = new List<string>();

            string[] skillListSplit = skills.Split(',');

            foreach (var skill in skillListSplit)
            {
                skillsList.Add(skill.Trim().ToLower());
            }

            return skillsList;
        }
    }
}
