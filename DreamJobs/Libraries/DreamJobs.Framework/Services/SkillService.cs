using DreamJobs.Framework.Entities;
using DreamJobs.Framework.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillUnitOfWork _skillUnitOfWork;

        public SkillService(ISkillUnitOfWork skillUnitOfWork)
        {
            _skillUnitOfWork = skillUnitOfWork;
        }

        public async Task AddAsync(IList<Skill> skills)
        {
            foreach (var skill in skills)
            {
                var count = await _skillUnitOfWork.SkillRepository.GetCountAsync(x => x.Name == skill.Name
                    && x.Id != skill.Id);
                if(count == 0)
                {
                    await _skillUnitOfWork.SkillRepository.AddAsync(skill);
                    await _skillUnitOfWork.SaveAsync();
                }
            }
        }
        
        public async Task<Skill> GetSkillByNameAsync(string skillName)
        {
            var skills = await _skillUnitOfWork.SkillRepository.GetAsync( s => s.Name == skillName);
            return skills.FirstOrDefault();
        }

        public async Task<IList<Skill>> GetAllSkillAsync()
        {
            return await _skillUnitOfWork.SkillRepository.GetAllAsync();
        }
    }
}
