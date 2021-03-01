using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class AddCompanyProfileModel : BaseModel
    {
        public string Name { get; set; }
        public string AboutCompany { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        private ICompanyService _companyService;

        public AddCompanyProfileModel()
        {
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public AddCompanyProfileModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task AddProfileDetails(string userName)
        {
            var user = await base.GetUserAsync(userName);

            var companyDetails = new DreamJobs.Framework.Entities.Company();

            companyDetails.UserId = user.Id;
            companyDetails.Name = this.Name;
            companyDetails.AboutCompany = this.AboutCompany;
            companyDetails.Category = this.Category;
            companyDetails.Address = this.Address;
            companyDetails.Website = this.Website;

            await _companyService.AddAsync(companyDetails);
        }
    }
}
