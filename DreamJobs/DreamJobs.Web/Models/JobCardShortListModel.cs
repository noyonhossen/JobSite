using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class JobCardShortListModel
    {
        public Guid JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> Vacancy { get; set; }
        public string JobLocation { get; set; }
        public string EducationRequired { get; set; }
        public string ExperienceRequirements { get; set; }
        public DateTime DeadLine { get; set; }
        public string SkillsRequired { get; set; }
        public string SkillsMatched { get; set; }
        public int TotalSkillsMatched { get; set; }
        public int TotalSkillsRequired { get; set; }
    }
}
