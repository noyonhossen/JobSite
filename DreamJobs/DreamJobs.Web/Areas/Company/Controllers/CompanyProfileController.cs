using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Company.Controllers
{
    [Area("Company")]
    public class CompanyProfileController : Controller
    {
        public async Task<IActionResult> ViewCompanyProfile()
        {
            var userName = User.Identity.Name;
            var model = new ViewCompanyProfileModel();
            await model.LoadModelDataAsync(userName);
            return View(model);
        }

        public IActionResult EditCompanyProfile()
        {
            return View();
        }

    }
}
