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
    public class AddCategoryModel
    {
        [Required(ErrorMessage = "Please Enter Category")]
        public string CategoryName { get; set; }

        private ICategoryService _categoryService;

        public AddCategoryModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public AddCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        internal async Task AddCategory()
        {
            var category = new Category()
            {
                Name = this.CategoryName
            };

            await _categoryService.AddAsync(category);
        }
    }
}
