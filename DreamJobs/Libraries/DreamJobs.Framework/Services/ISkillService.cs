using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public interface ISkillService
    {
        Task AddAsync(IList<Skill> skills);
        Task<Skill> GetSkillByNameAsync(string skillName);
        Task<IList<Skill>> GetAllSkillAsync();
        Task<List<Skill>> GetEmployeeSkillsAsync(IList<EmployeeSkill> employeeSkills);
        Task<List<Skill>> GetJobSkillsAsync(IList<JobSkill> jobSkills);
        Task<List<string>> GetMatchedSkillsAsync(IList<Skill> requiredJobSkills, IList<EmployeeSkill> employeeSkills);
    }
}
