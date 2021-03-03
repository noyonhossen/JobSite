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
            await model.GetJobsByCategoryAsync(category);
            return View(model);
        }
    }
}
