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
            try
            {
                var userName = User.Identity.Name;
                var model = new ViewCompanyProfileModel();
                await model.LoadModelDataAsync(userName);
                return View(model);
            }
            catch
            {

                return RedirectToAction("AddCompanyProfile");
            }
        }

        public async Task<IActionResult> EditCompanyProfile()
        {
            var model = new EditCompanyProfileModel();
            await model.LoadModelDataAsync(User.Identity.Name);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompanyProfile(EditCompanyProfileModel model)
        {
            if (ModelState.IsValid)
            {
                await model.EditProfile(User.Identity.Name);
                return RedirectToAction("ViewCompanyProfile");
            }
            return View(model);
        }

        public IActionResult AddCompanyProfile()
        {
            var model = new AddCompanyProfileModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCompanyProfile(AddCompanyProfileModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddProfileDetails(User.Identity.Name);
                return RedirectToAction("ViewCompanyProfile");
            }
            return View(model);
        }

    }
}
