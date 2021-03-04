using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class CategoryModel
    {
        public IList<Category> Categories { get; set; }
        private ICategoryService _categoryService;

        public CategoryModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public CategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        internal async Task GetAllCategoryAsync()
        {
            Categories = await _categoryService.GetAllCategoryAsync();
        }
    }
}
