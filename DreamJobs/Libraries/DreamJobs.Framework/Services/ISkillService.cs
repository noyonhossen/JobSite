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
    }
}
