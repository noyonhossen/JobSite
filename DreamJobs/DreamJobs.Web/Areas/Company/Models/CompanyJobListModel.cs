using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class CompanyJobListModel : BaseModel
    {
        public IList<JobCardShortListModel> JobCardShortLists { get; set; }
        private IJobService _jobService;
        private ICompanyService _companyService;

        public CompanyJobListModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public CompanyJobListModel(IJobService jobService, ICompanyService companyService)
        {
            _jobService = jobService;
            _companyService = companyService;
        }

        internal async Task GetCompanyAllJobAsync(string userName)
        {
            var jobCardShortLists = new List<JobCardShortListModel>();
            var user = await base.GetUserAsync(userName);
            var companyDetails = await _companyService.GetCompanyDetailsAsync(user.Id);

            var companyJobs = await _jobService.GetCompanyAllJobAsync(companyDetails);

            foreach (var companyJob in companyJobs)
            {
                var jobCardShortList = new JobCardShortListModel
                {
                    JobId = companyJob.Id,
                    JobTitle = companyJob.JobTitle,
                    Vacancy = companyJob.Vacancy,
                    CompanyName = companyDetails.Name,
                    JobLocation = companyJob.JobLocation,
                    EducationRequired = companyJob.EducationRequired,
                    ExperienceRequirements = companyJob.ExperienceRequirements,
                    DeadLine = companyJob.DeadLine,
                    SkillsRequired = companyJob.SkillsRequired
                };

                jobCardShortLists.Add(jobCardShortList);
            }

            JobCardShortLists = jobCardShortLists;
        }
    }
}
