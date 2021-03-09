﻿using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Models
{
    public class PublicJobDetailsModel : BaseModel
    {
        public JobDetailsModel JobDetails { get; set; }
        private IJobService _jobService;
        private ISkillService _skillService;

        public PublicJobDetailsModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public PublicJobDetailsModel(IJobService jobService,
            ISkillService skillService)
        {
            _jobService = jobService;
            _skillService = skillService;
        }

        internal async Task GetJobDetailsAsync(Guid jobId, string userName)
        {
            var employee = new Employee();
            var jobDetails = await _jobService.GetJobDetailsAsync(jobId);

            if (userName != null)
            {
                employee = await base.GetEmployeeAsync(userName);
            }

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
                //SkillsMatched = userName == null ? "" : (base.GetUserMatchedSkillsAsync(jobDetails.SkillsRequired, employee.Skills)).matchedSkills,
                //TotalSkillsMatched = userName == null ? 0 : (base.GetUserMatchedSkillsAsync(jobDetails.SkillsRequired, employee.Skills)).totalSkills,
                //TotalSkillsRequired = userName == null ? 0 : (base.GetUserMatchedSkillsAsync(jobDetails.SkillsRequired, employee.Skills)).totalSkillsRequired,
                SkillsRequired = await _skillService.GetJobSkillsAsync(jobDetails.JobSkills)
            };
            jobDetail.TotalSkillsRequired = jobDetail.SkillsRequired.Count;

            JobDetails = jobDetail;
        }
    }
}
