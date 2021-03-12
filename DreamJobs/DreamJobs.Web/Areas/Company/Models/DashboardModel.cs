using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class DashboardModel : BaseModel
    {
        public int TotalJobPosted { get; set; }
        private ICompanyService _companyService;
        private IJobService _jobService;

        public DashboardModel()
        {
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
        }

        public DashboardModel(ICompanyService companyService,
            IJobService jobService)
        {
            _companyService = companyService;
            _jobService = jobService;
        }

        internal async Task GetTotalJobPostedByCompany(string userName)
        {
            var user = await base.GetUserAsync(userName);
            var companyDetails = await _companyService.GetCompanyDetailsAsync(user.Id);

            TotalJobPosted = await _jobService.GetCompanyJobCount(companyDetails);
        }
    }
}
