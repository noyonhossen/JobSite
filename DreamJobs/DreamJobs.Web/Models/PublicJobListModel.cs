using Autofac;
using DreamJobs.Framework.Entities;
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

        internal async Task GetJobsByCategoryAsync(string category, string userName)
        {
            var employee = new Employee();
            var jobCardShortLists = new List<JobCardShortListModel>();
            var jobs = await _jobService.GetJobsByCategoryAsync(category);

            if (userName != null)
            {
                employee = await base.GetEmployeeAsync(userName);
            }

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
                    SkillsRequired = job.SkillsRequired,
                    SkillsMatched = userName == null ? "" : (base.GetUserMatchedSkillsAsync(job.SkillsRequired, employee.Skills)).matchedSkills,
                    TotalSkillsMatched = userName == null ? 0 : (base.GetUserMatchedSkillsAsync(job.SkillsRequired, employee.Skills)).totalSkills,
                    TotalSkillsRequired = userName == null ? 0 : (base.GetUserMatchedSkillsAsync(job.SkillsRequired, employee.Skills)).totalSkillsRequired
                };

                jobCardShortLists.Add(jobCardShortList);
            }

            JobCardShortLists = jobCardShortLists;
        }
    }
}
