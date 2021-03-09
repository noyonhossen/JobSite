using Autofac;
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
        [Required(ErrorMessage = "Please Select Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string EmailForApply { get; set; }
        public IList<Category> Categories { get; set; }
        [Required(ErrorMessage = "Please Select at least 1 Skill")]
        public List<string> SkillsRequired { get; set; }
        public IList<Skill> SkillList { get; set; }

        private ICategoryService _categoryService;
        private IJobService _jobService;
        private ICompanyService _companyService;
        private ISkillService _skillService;

        public AddJobModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
            var today = DateTime.Today;
            DeadLine = today.AddDays(1);
        }

        public AddJobModel(IJobService jobService,
            ICompanyService companyService,
            ICategoryService categoryService,
            ISkillService skillService)
        {
            _jobService = jobService;
            _companyService = companyService;
            _categoryService = categoryService;
            _skillService = skillService;
            var today = DateTime.Today;
            DeadLine = today.AddDays(1);
        }

        internal async Task LoadAllSkills()
        {
            SkillList = await _skillService.GetAllSkillAsync();
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
            var jobSkills = new List<JobSkill>();

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
                Category = this.Category,
                EmailForApply = this.EmailForApply
            };

            foreach (var skill in SkillsRequired)
            {
                var jobSkill = new JobSkill
                {
                    SkillId = Guid.Parse(skill),
                    JobId = user.Id
                };
                jobSkills.Add(jobSkill);
            }

            job.JobSkills = jobSkills;

            await _jobService.AddAsync(job);
        }
    }
}
