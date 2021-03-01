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
        public IActionResult AddJob()
        {
            var model = new AddJobModel();
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
    }
}
