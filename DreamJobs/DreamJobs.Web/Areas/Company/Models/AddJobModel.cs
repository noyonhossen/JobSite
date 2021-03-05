﻿using Autofac;
using DreamJobs.Framework.Entities;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class AddJobModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Job title")]
        public string JobTitle { get; set; }
        public string JobContext { get; set; }
        [Required(ErrorMessage = "Please write about Job Responsibilities")]
        public string JobResponsibilities { get; set; }
        public Nullable<int> Vacancy { get; set; }
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
        [Required(ErrorMessage = "Please Enter Required Skills")]
        public string SkillsRequired { get; set; }
        [Required(ErrorMessage = "Please Enter Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string EmailForApply { get; set; }
        public IList<Category> Categories { get; set; }

        private ICategoryService _categoryService;
        private IJobService _jobService;
        private ICompanyService _companyService;

        public AddJobModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            var today = DateTime.Today;
            DeadLine = today.AddDays(1);
        }

        public AddJobModel(IJobService jobService,
            ICompanyService companyService,
            ICategoryService categoryService)
        {
            _jobService = jobService;
            _companyService = companyService;
            _categoryService = categoryService;
            var today = DateTime.Today;
            DeadLine = today.AddDays(1);
        }

        internal async Task GetAllCategoryAsync()
        {
            Categories = await _categoryService.GetAllCategoryAsync();
        }

        internal async Task AddJobAsync(string userName)
        {
            var user = await base.GetUserAsync(userName);
            var companyDetails = await _companyService.GetCompanyDetailsAsync(user.Id);
            var dateTime = DateTime.Now;

            var job = new Job
            {
                CompanyId = companyDetails.Id,
                JobTitle = this.JobTitle,
                JobContext = this.JobContext ?? "NA",
                JobResponsibilities = this.JobResponsibilities,
                Vacancy = this.Vacancy ?? 1,
                Salary = this.Salary ?? "Negotiable",
                JobLocation = this.JobLocation ?? "Anywhere in Bangladesh",
                WorkPlace = this.WorkPlace ?? "Work at office",
                EducationRequired = this.EducationRequired ?? "NA",
                ExperienceRequirements = this.ExperienceRequirements ?? "NA",
                DeadLine = this.DeadLine,
                EmploymentStatus = this.EmploymentStatus ?? "Full-time",
                Age = this.Age ?? "NA",
                AdditionalRequirements = this.AdditionalRequirements ?? "NA",
                CompensationAndOtherBenefits = this.CompensationAndOtherBenefits ?? "NA",
                PublishedDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day),
                IsMaleApplicable = this.IsMaleApplicable,
                IsFemaleApplicable = this.IsFemaleApplicable,
                IsOtherApplicable = this.IsOtherApplicable,
                SkillsRequired = this.SkillsRequired,
                Category = this.Category,
                EmailForApply = this.EmailForApply
            };

            await _jobService.AddAsync(job);
        }
    }
}
