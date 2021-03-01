using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class EditCompanyProfileModel : BaseModel
    {
        public string Name { get; set; }
        public string AboutCompany { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        private ICompanyService _companyService;

        public EditCompanyProfileModel()
        {
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public EditCompanyProfileModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task LoadModelDataAsync(string username)
        {
            var user = await base.GetUserAsync(username);

            var companyDetails = await _companyService.GetCompanyDetailsAsync(user.Id);

            Name = companyDetails.Name;
            AboutCompany = companyDetails.AboutCompany;
            Category = companyDetails.Category;
            Address = companyDetails.Address;
            Website = companyDetails.Website;
        }

        public async Task EditProfile(string userName)
        {
            var user = await base.GetUserAsync(userName);

            var companyDetails = await _companyService.GetCompanyDetailsAsync(user.Id);

            companyDetails.Name = this.Name;
            companyDetails.AboutCompany = this.AboutCompany;
            companyDetails.Category = this.Category;
            companyDetails.Address = this.Address;
            companyDetails.Website = this.Website;

            await _companyService.UpdateAsync(companyDetails);
        }
    }
}
