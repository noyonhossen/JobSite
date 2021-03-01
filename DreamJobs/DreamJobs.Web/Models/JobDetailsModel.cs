﻿using System;

namespace DreamJobs.Web.Models
{
    public class JobDetailsModel
    {
        public string CompanyName { get; set; }
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
        public string SkillsMatched { get; set; }
    }
}
