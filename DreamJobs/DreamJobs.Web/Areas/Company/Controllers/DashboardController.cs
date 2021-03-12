using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Company.Controllers
{
    [Area("Company"), Authorize(Policy = "CompanyPolicy")]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new DashboardModel();
            await model.GetTotalJobPostedByCompany(User.Identity.Name);
            return View(model);
        }
    }
}
