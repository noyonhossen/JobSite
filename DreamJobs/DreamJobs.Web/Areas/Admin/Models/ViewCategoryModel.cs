using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Admin.Models
{
    public class ViewCategoryModel
    {
        public IList<Category> Categories { get; set; }

        private ICategoryService _categoryService;

        public ViewCategoryModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public ViewCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        internal async Task LoadModelDataAsync()
        {
            Categories =  await _categoryService.GetAllCategoryAsync();
        }
    }
}
