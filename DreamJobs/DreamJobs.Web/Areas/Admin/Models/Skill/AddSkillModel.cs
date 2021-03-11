using Autofac;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Admin.Models.Skill
{
    public class AddSkillModel
    {
        [Required(ErrorMessage = "Please Enter Skill")]
        public string SkillName { get; set; }

        private ISkillService _skillService;

        public AddSkillModel()
        {
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public AddSkillModel(ISkillService skillService)
        {
            _skillService = skillService;
        }

        internal async Task AddSkill()
        {
            var skill = new DreamJobs.Framework.Entities.Skill()
            {
                Name = this.SkillName
            };

            await _skillService.AddSkillAsync(skill);
        }
    }
}
