using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "InternalUser")]
    public class CategoryController : Controller
    {
        public IActionResult Add()
        {
            var model = new AddCategoryModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddCategory();
                return RedirectToAction("ViewCategory", "Category", new { Area = "Admin" });
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = new EditCategoryModel();
            await model.LoadModelDataAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await model.EditCategory();
                return RedirectToAction("ViewCategory", "Category", new { Area = "Admin" });
            }
            return View(model);
        }

        public async Task<IActionResult> ViewCategory()
        {
            var model = new ViewCategoryModel();
            await model.LoadModelDataAsync();
            return View(model);
        }
    }
}
