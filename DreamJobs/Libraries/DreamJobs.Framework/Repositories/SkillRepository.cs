using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public class SkillRepository : Repository<Skill, Guid, FrameworkContext>, ISkillRepository
    {
        public SkillRepository(FrameworkContext dbContext) : base(dbContext)
        {

        }
    }
}
