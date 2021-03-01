using DreamJobs.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Entities
{
    public class JobSkill : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
