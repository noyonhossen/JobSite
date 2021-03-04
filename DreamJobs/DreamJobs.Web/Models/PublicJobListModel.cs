using Autofac;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class PublicJobListModel : BaseModel
    {
        public IList<JobCardShortListModel> JobCardShortLists { get; set; }
        private IJobService _jobService;

        public PublicJobListModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
        }

        public PublicJobListModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        internal async Task GetJobsByCategoryAsync(string category)
        {
            var jobCardShortLists = new List<JobCardShortListModel>();
            var jobs = await _jobService.GetJobsByCategoryAsync(category);

            foreach (var job in jobs)
            {
                var jobCardShortList = new JobCardShortListModel
                {
                    JobId = job.Id,
                    JobTitle = job.JobTitle,
                    Vacancy = job.Vacancy,
                    CompanyName = job.Company.Name,
                    JobLocation = job.JobLocation,
                    EducationRequired = job.EducationRequired,
                    ExperienceRequirements = job.ExperienceRequirements,
                    DeadLine = job.DeadLine,
                    SkillsRequired = job.SkillsRequired
                };

                jobCardShortLists.Add(jobCardShortList);
            }

            JobCardShortLists = jobCardShortLists;
        }
    }
}
