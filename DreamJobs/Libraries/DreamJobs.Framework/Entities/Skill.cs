using DreamJobs.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Entities
{
    public class Skill : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<JobSkill> JobSkills { get; set; }
    }
}
