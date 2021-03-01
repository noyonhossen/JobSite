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
                await model.AddJobAsync();
                return RedirectToAction("ViewCompanyProfile");
            }
            return View(model);
        }
    }
}
