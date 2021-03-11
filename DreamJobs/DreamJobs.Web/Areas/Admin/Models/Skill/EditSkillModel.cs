using Autofac;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Admin.Models.Skill
{
    public class EditSkillModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Skill")]
        public string SkillName { get; set; }

        private ISkillService _skillService;

        public EditSkillModel()
        {
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public EditSkillModel(ISkillService skillService)
        {
            _skillService = skillService;
        }

        internal async Task LoadModelDataAsync(Guid id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill != null)
            {
                Id = skill.Id;
                SkillName = skill.Name;
            }
        }

        internal async Task EditSkill()
        {
            var skill = new DreamJobs.Framework.Entities.Skill()
            {
                Id = this.Id,
                Name = this.SkillName
            };

            await _skillService.UpdateAsync(skill);
        }
    }
}
