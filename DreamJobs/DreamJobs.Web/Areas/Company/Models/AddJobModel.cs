using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class AddJobModel
    {
        public string JobTitle { get; set; }
        public string JobContext { get; set; }
        public string JobResponsibilities { get; set; }
        public int Vacancy { get; set; }
        public string Salary { get; set; }
        public string JobLocation { get; set; }
        public string WorkPlace { get; set; }
        public string EducationRequired { get; set; }
        public string ExperienceRequirements { get; set; }
        public DateTime DeadLine { get; set; }
        public string EmploymentStatus { get; set; }
        public string Age { get; set; }
        public string AdditionalRequirements { get; set; }
        public string CompensationAndOtherBenefits { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsMaleApplicable { get; set; }
        public bool IsFemaleApplicable { get; set; }
        public bool IsOtherApplicable { get; set; }
        public string SkillsRequired { get; set; }
        private IJobService _jobService;

        public AddJobModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
        }

        public AddJobModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        internal async Task AddJobAsync()
        {
            var job = new Job
            {
                JobTitle = this.JobTitle,
                JobContext = this.JobContext,
                JobResponsibilities = this.JobResponsibilities,
                Vacancy = this.Vacancy,
                Salary = this.Salary,
                JobLocation = this.JobLocation,
                WorkPlace = this.WorkPlace,
                EducationRequired = this.EducationRequired,
                ExperienceRequirements = this.ExperienceRequirements,
                DeadLine = this.DeadLine,
                EmploymentStatus = this.EmploymentStatus,
                Age = this.Age,
                AdditionalRequirements = this.AdditionalRequirements,
                CompensationAndOtherBenefits = this.CompensationAndOtherBenefits,
                PublishedDate = DateTime.Now,
                IsMaleApplicable = this.IsMaleApplicable,
                IsFemaleApplicable = this.IsFemaleApplicable,
                IsOtherApplicable = this.IsOtherApplicable,
                SkillsRequired = this.SkillsRequired
            };

            await _jobService.AddAsync(job);
        }
    }
}
