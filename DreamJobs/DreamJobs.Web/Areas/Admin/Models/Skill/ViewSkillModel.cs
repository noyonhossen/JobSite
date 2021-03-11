using Autofac;
using DreamJobs.Framework.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Admin.Models.Skill
{
    public class ViewSkillModel
    {
        public IList<DreamJobs.Framework.Entities.Skill> Skills { get; set; }

        private ISkillService _skillService;

        public ViewSkillModel()
        {
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public ViewSkillModel(ISkillService skillService)
        {
            _skillService = skillService;
        }

        internal async Task LoadModelDataAsync()
        {
            Skills = await _skillService.GetAllSkillAsync();
        }
    }
}
