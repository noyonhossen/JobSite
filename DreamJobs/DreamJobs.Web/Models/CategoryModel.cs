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
        public int TotalJobsPosted { get; set; }
        public int TotalJobsPostedToday { get; set; }
        public int TotalCompanies { get; set; }
        private ICategoryService _categoryService;
        private IJobService _jobService;
        private ICompanyService _companyService;

        public CategoryModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public CategoryModel(ICategoryService categoryService,
                                IJobService jobService,
                                ICompanyService companyService)
        {
            _categoryService = categoryService;
            _jobService = jobService;
            _companyService = companyService;
        }

        internal async Task GetAllCategoryAsync()
        {
            Categories = await _categoryService.GetAllCategoryAsync();
        }

        internal async Task GetTotalJobsPostedAsync()
        {
            TotalJobsPosted = await _jobService.GetTotalJobsAsync();
        }

        internal async Task GetTotalJobsPostedTodayAsync()
        {
            TotalJobsPostedToday = await _jobService.GetJobsPostedTodayAsync();
        }

        internal async Task GetTotalCompanyAsync()
        {
            TotalCompanies = await _companyService.GetTotalCompanyAsync();
        }
    }
}
