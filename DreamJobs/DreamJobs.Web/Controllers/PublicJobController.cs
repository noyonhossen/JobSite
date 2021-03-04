using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Controllers
{
    public class PublicJobController : Controller
    {
        public async Task<IActionResult> ViewJobs(string category)
        {
            var model = new PublicJobListModel();
            await model.GetJobsByCategoryAsync(category, User.Identity.Name);
            return View(model);
        }

        public async Task<IActionResult> ViewJobDetails(Guid jobId)
        {
            var model = new PublicJobDetailsModel();
            await model.GetJobDetailsAsync(jobId, User.Identity.Name);
            return View(model);
        }
    }
}
