using Autofac;
using DreamJobs.Framework.Services;
using DreamJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Web.Areas.Company.Models
{
    public class ViewCompanyProfileModel : BaseModel
    {
        public string Name { get; set; }
        public string AboutCompany { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        private ICompanyService _companyService;

        public ViewCompanyProfileModel()
        {
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public ViewCompanyProfileModel(ICompanyService companyService)
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
    }
}
