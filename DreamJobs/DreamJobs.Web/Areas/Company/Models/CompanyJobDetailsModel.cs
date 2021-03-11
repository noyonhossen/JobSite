using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class CompanyJobDetailsModel
    {
        public JobDetailsModel JobDetails { get; set; }
        private IJobService _jobService;
        private ISkillService _skillService;

        public CompanyJobDetailsModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public CompanyJobDetailsModel(IJobService jobService,
            ISkillService skillService)
        {
            _jobService = jobService;
            _skillService = skillService;
        }

        internal async Task GetCompanyAllJobAsync(Guid jobId)
        {
            var jobDetails = await _jobService.GetJobDetailsAsync(jobId);

            var jobDetail = new JobDetailsModel
            {
                CompanyName = jobDetails.Company.Name,
                JobTitle = jobDetails.JobTitle,
                JobContext = jobDetails.JobContext,
                JobResponsibilities = jobDetails.JobResponsibilities,
                Vacancy = jobDetails.Vacancy,
                Salary = jobDetails.Salary,
                JobLocation = jobDetails.JobLocation,
                WorkPlace = jobDetails.WorkPlace,
                EducationRequired = jobDetails.EducationRequired,
                ExperienceRequirements = jobDetails.ExperienceRequirements,
                DeadLine = jobDetails.DeadLine,
                EmploymentStatus = jobDetails.EmploymentStatus,
                Age = jobDetails.Age,
                AdditionalRequirements = jobDetails.AdditionalRequirements,
                CompensationAndOtherBenefits = jobDetails.CompensationAndOtherBenefits,
                PublishedDate = jobDetails.PublishedDate,
                IsMaleApplicable = jobDetails.IsMaleApplicable,
                IsFemaleApplicable = jobDetails.IsFemaleApplicable,
                IsOtherApplicable = jobDetails.IsOtherApplicable,
                SkillsList = jobDetails.JobSkills,
                Category = jobDetails.Category,
                EmailForApply = jobDetails.EmailForApply,
                CompanyAddress = jobDetails.Company.Address,
                CompanyWebsite = jobDetails.Company.Website,
                SkillsRequired = await _skillService.GetJobSkillsAsync(jobDetails.JobSkills)
            };

            JobDetails = jobDetail;
        }
    }
}
