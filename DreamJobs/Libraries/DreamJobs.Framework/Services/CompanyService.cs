using DreamJobs.Framework.UnitOfWorks;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyUnitOfWork _companyUnitOfWork;
        private readonly IUserService<ApplicationUser> _userService;

        public CompanyService(ICompanyUnitOfWork companyUnitOfWork,
            IUserService<ApplicationUser> userService)
        {
            _companyUnitOfWork = companyUnitOfWork;
            _userService = userService;
        }

        public async Task<Entities.Company> GetCompanyDetailsAsync(Guid id)
        {
            return await _companyUnitOfWork.CompanyRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Entities.Company company)
        {
            await _companyUnitOfWork.CompanyRepository.EditAsync(company);
            await _companyUnitOfWork.SaveAsync();
        }

        public async Task AddAsync(Entities.Company company)
        {
            await _companyUnitOfWork.CompanyRepository.AddAsync(company);
            await _companyUnitOfWork.SaveAsync();
        }
    }
}
