using DreamJobs.Framework.Entities;
using DreamJobs.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public class JobService : IJobService
    {
        private readonly IJobUnitOfWork _jobUnitOfWork;

        public JobService(IJobUnitOfWork jobUnitOfWork)
        {
            _jobUnitOfWork = jobUnitOfWork;
        }

        public async Task AddAsync(Job job)
        {
            await _jobUnitOfWork.JobRepository.AddAsync(job);
            await _jobUnitOfWork.SaveAsync();
        }

        public async Task<IList<Job>> GetCompanyAllJobAsync(Company companyInfo)
        {
            var companyJobList = await _jobUnitOfWork.JobRepository.GetAsync(c => c.CompanyId == companyInfo.Id);
            return companyJobList;
        }
    }
}
