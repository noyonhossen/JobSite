using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Company.Controllers
{
    [Area("Company")]
    public class JobController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AddJob()
        {
            var model = new AddJobModel();
            await model.LoadAllSkills();
            await model.GetAllCategoryAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddJob(AddJobModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddJobAsync(User.Identity.Name);
                return RedirectToAction("ViewJobs");
            }
            return View(model);
        }

        public async Task<IActionResult> ViewJobs()
        {
            var model = new CompanyJobListModel();
            await model.GetCompanyAllJobAsync(User.Identity.Name);
            return View(model);
        }

        public async Task<IActionResult> ViewJobDetails(Guid jobId)
        {
            var model = new CompanyJobDetailsModel();
            await model.GetCompanyAllJobAsync(jobId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid jobId)
        {
            var model = new EditJobModel();
            await model.LoadModelData(jobId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditJobModel model)
        {
            if (ModelState.IsValid)
            {
                await model.EditJobAsync(User.Identity.Name, model.JobId);
                return RedirectToAction("ViewJobDetails", "Job", new { Area = "Company", jobId = model.JobId });
            }
            return View(model);
        }
    }
}
