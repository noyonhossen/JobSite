using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using DreamJobs.Membership.Constants;
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
        private ISkillService _skillService;

        public PublicJobListModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public PublicJobListModel(IJobService jobService,
            ISkillService skillService)
        {
            _jobService = jobService;
            _skillService = skillService;
        }

        internal async Task GetJobsByCategoryAsync(string category, string userName)
        {
            var employee = new Employee();
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
                    SkillsList = job.JobSkills,
                    SkillsRequired = await _skillService.GetJobSkillsAsync(job.JobSkills)
                };

                if (userName != null)
                {
                    var claims = await base.GetUserClaimsAsync(userName);
                    if(claims.Where(x => x.Type == MembershipClaims.MemberClaimType).Any())
                    {
                        employee = await base.GetEmployeeAsync(userName);
                        jobCardShortList.SkillsMatched = await _skillService.GetMatchedSkillsAsync(jobCardShortList.SkillsRequired, employee.EmployeeSkills);
                        jobCardShortList.TotalSkillsMatched = jobCardShortList.SkillsMatched.Count;
                    }
                }
                
                jobCardShortList.TotalSkillsRequired = jobCardShortList.SkillsRequired.Count;
                jobCardShortLists.Add(jobCardShortList);
            }

            JobCardShortLists = jobCardShortLists;
        }
    }
}
