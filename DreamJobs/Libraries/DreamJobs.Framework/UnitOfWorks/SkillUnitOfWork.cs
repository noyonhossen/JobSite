using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public class SkillUnitOfWork : UnitOfWork, ISkillUnitOfWork
    {
        public ISkillRepository SkillRepository { get; set; }

        public SkillUnitOfWork(FrameworkContext context,
            ISkillRepository skillRepository)
            : base(context)
        {
            SkillRepository = skillRepository;
        }
    }
}
