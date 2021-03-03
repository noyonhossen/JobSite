using Autofac;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class PublicJobDetailsModel
    {
        public JobDetailsModel JobDetails { get; set; }
        private IJobService _jobService;

        public PublicJobDetailsModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
        }

        public PublicJobDetailsModel(IJobService jobService, ICompanyService companyService)
        {
            _jobService = jobService;
        }

        internal async Task GetJobDetailsAsync(Guid jobId)
        {
            var jobDetails = await _jobService.GetJobDetailsAsync(jobId);

            var jobDetail = new JobDetailsModel
            {
                //CompanyName = jobDetails.Company.Name,
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
                SkillsRequired = jobDetails.SkillsRequired,
                Category = jobDetails.Category,
                EmailForApply = jobDetails.EmailForApply,
                //CompanyAddress = jobDetails.Company.Address,
                //CompanyWebsite = jobDetails.Company.Website
            };

            JobDetails = jobDetail;
        }
    }
}
