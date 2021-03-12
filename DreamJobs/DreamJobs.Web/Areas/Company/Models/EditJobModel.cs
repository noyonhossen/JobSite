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
    public class EditJobModel : BaseModel
    {
        public Guid JobId { get; set; }
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
        public IList<Skill> AllSkills { get; set; }
        public IList<Skill> JobSkillList { get; set; }
        public IList<JobSkill> JobSkills { get; set; }

        private ICategoryService _categoryService;
        private IJobService _jobService;
        private ICompanyService _companyService;
        private ISkillService _skillService;

        public EditJobModel()
        {
            _jobService = Startup.AutofacContainer.Resolve<IJobService>();
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _skillService = Startup.AutofacContainer.Resolve<ISkillService>();
        }

        public EditJobModel(IJobService jobService,
            ICompanyService companyService,
            ICategoryService categoryService,
            ISkillService skillService)
        {
            _jobService = jobService;
            _companyService = companyService;
            _categoryService = categoryService;
            _skillService = skillService;
        }

        internal async Task LoadModelData(Guid jobId)
        {
            var jobDetails = await _jobService.GetJobDetailsAsync(jobId);

            JobId = jobDetails.Id;
            JobTitle = jobDetails.JobTitle;
            JobContext = jobDetails.JobContext;
            JobResponsibilities = jobDetails.JobResponsibilities;
            Vacancy = jobDetails.Vacancy;
            Salary = jobDetails.Salary;
            JobLocation = jobDetails.JobLocation;
            WorkPlace = jobDetails.WorkPlace;
            EducationRequired = jobDetails.EducationRequired;
            ExperienceRequirements = jobDetails.ExperienceRequirements;
            DeadLine = jobDetails.DeadLine;
            EmploymentStatus = jobDetails.EmploymentStatus;
            Age = jobDetails.Age;
            AdditionalRequirements = jobDetails.AdditionalRequirements;
            CompensationAndOtherBenefits = jobDetails.CompensationAndOtherBenefits;
            PublishedDate = jobDetails.PublishedDate;
            IsMaleApplicable = jobDetails.IsMaleApplicable;
            IsFemaleApplicable = jobDetails.IsFemaleApplicable;
            IsOtherApplicable = jobDetails.IsOtherApplicable;
            Category = jobDetails.Category;
            EmailForApply = jobDetails.EmailForApply;
            JobSkills = jobDetails.JobSkills;

            JobSkillList = await _skillService.GetJobSkillsAsync(JobSkills);
            AllSkills = await _skillService.GetAllSkillAsync();
            Categories = await _categoryService.GetAllCategoryAsync();
        }

        internal async Task EditJobAsync(string userName,Guid jobId)
        {
            AllSkills = await _skillService.GetAllSkillAsync();
            Categories = await _categoryService.GetAllCategoryAsync();
            var user = await base.GetUserAsync(userName);
            var companyDetails = await _companyService.GetCompanyDetailsAsync(user.Id);
            var jobDetails = await _jobService.GetJobDetailsAsync(jobId);
            var jobSkills = new List<JobSkill>();

            jobDetails.CompanyId = companyDetails.Id;
            jobDetails.JobTitle = this.JobTitle;
            jobDetails.JobContext = this.JobContext ?? "NA";
            jobDetails.JobResponsibilities = this.JobResponsibilities;
            jobDetails.Vacancy = this.Vacancy ?? 1;
            jobDetails.Salary = this.Salary ?? "Negotiable";
            jobDetails.JobLocation = this.JobLocation ?? "Anywhere in Bangladesh";
            jobDetails.WorkPlace = this.WorkPlace ?? "Work at office";
            jobDetails.EducationRequired = this.EducationRequired ?? "NA";
            jobDetails.ExperienceRequirements = this.ExperienceRequirements ?? "NA";
            jobDetails.DeadLine = this.DeadLine;
            jobDetails.EmploymentStatus = this.EmploymentStatus ?? "Full-time";
            jobDetails.Age = this.Age ?? "NA";
            jobDetails.AdditionalRequirements = this.AdditionalRequirements ?? "NA";
            jobDetails.CompensationAndOtherBenefits = this.CompensationAndOtherBenefits ?? "NA";
            jobDetails.PublishedDate = this.PublishedDate;
            jobDetails.IsMaleApplicable = this.IsMaleApplicable;
            jobDetails.IsFemaleApplicable = this.IsFemaleApplicable;
            jobDetails.IsOtherApplicable = this.IsOtherApplicable;
            jobDetails.Category = this.Category;
            jobDetails.EmailForApply = this.EmailForApply;

            foreach (var skill in SkillsRequired)
            {
                var jobSkill = new JobSkill
                {
                    SkillId = Guid.Parse(skill),
                    JobId = user.Id
                };
                jobSkills.Add(jobSkill);
            }

            jobDetails.JobSkills = jobSkills;

            await _jobService.UpdateJobAsync(jobDetails);
        }
    }
}
