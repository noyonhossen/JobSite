using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Admin.Models.Skill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "InternalUser")]
    public class SkillController : Controller
    {
        public IActionResult Add()
        {
            var model = new AddSkillModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddSkillModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddSkill();
                return RedirectToAction("ViewSkill", "Skill", new { Area = "Admin" });
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = new EditSkillModel();
            await model.LoadModelDataAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSkillModel model)
        {
            if (ModelState.IsValid)
            {
                await model.EditSkill();
                return RedirectToAction("ViewSkill", "Skill", new { Area = "Admin" });
            }
            return View(model);
        }

        public async Task<IActionResult> ViewSkill()
        {
            var model = new ViewSkillModel();
            await model.LoadModelDataAsync();
            return View(model);
        }
    }
}
