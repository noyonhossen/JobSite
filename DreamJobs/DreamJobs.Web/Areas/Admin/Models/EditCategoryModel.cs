using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Admin.Models
{
    public class EditCategoryModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Category")]
        public string CategoryName { get; set; }

        private ICategoryService _categoryService;

        public EditCategoryModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public EditCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        internal async Task LoadModelDataAsync(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category != null)
            {
                Id = category.Id;
                CategoryName = category.Name;
            }
        }

        internal async Task EditCategory()
        {
            var category = new Category()
            {
                Id = this.Id,
                Name = this.CategoryName
            };

            await _categoryService.UpdateAsync(category);
        }
    }
}
