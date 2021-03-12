using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Admin.Models;
using DreamJobs.Web.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Member.Controllers
{
    [Area("Member"), Authorize(Policy = "MemberPolicy")]
    public class EmployeeProfileController : Controller
    {
        public async Task<IActionResult> ViewEmployeeProfile()
        {
            try
            {
                var userName = User.Identity.Name;
                var model = new ViewEmployeeProfileModel();
                await model.LoadModelDataAsync(userName);
                return View(model);
            }
            catch
            {
                return RedirectToAction("AddEmployeeProfile");
            }
        }

        public async Task<IActionResult> EditEmployeeProfile()
        {
            try
            {
                var model = new EditEmployeeProfileModel();
                await model.LoadModelDataAsync(User.Identity.Name);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("AddEmployeeProfile");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployeeProfile(EditEmployeeProfileModel model)
        {
            if (ModelState.IsValid)
            {
                await model.EditProfile(User.Identity.Name);
                return RedirectToAction("ViewEmployeeProfile");
            }
            return View(model);
        }

        public async Task<IActionResult> AddEmployeeProfile()
        {
            var model = new AddEmployeeProfileModel();
            await model.LoadAllSkills();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeProfile(AddEmployeeProfileModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddProfileDetails(User.Identity.Name);
                return RedirectToAction("ViewEmployeeProfile", "EmployeeProfile", new { Area = "Member" });
            }
            return View(model);
        }
    }
}
