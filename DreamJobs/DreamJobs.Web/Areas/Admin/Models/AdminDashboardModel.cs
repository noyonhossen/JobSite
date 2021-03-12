using Autofac;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Admin.Models
{
    public class AdminDashboardModel
    {
        public int TotalJobsPosted { get; set; }
        public int TotalJobsPostedToday { get; set; }
        public int TotalCompanies { get; set; }
        public int TotalEmployee { get; set; }
        private IJobService _jobService;
        private ICompanyService _companyService;
        private IEmployeeService _employeeService;

        public AdminDashboardModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public AdminDashboardModel(IEmployeeService employeeService,
                                IJobService jobService,
                                ICompanyService companyService)
        {
            _employeeService = employeeService;
            _jobService = jobService;
            _companyService = companyService;
        }

        internal async Task LoadModelData()
        {
            TotalEmployee = await _employeeService.GetTotalEmployeeAsync();
            TotalCompanies = await _companyService.GetTotalCompanyAsync();
            TotalJobsPosted = await _jobService.GetTotalJobsAsync();
            TotalJobsPostedToday = await _jobService.GetJobsPostedTodayAsync();
        }
    }
}
