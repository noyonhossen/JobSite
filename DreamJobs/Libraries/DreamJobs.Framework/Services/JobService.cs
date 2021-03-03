using DreamJobs.Framework.Entities;
using DreamJobs.Framework.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public async Task<IList<Job>> GetJobsByCategoryAsync(string category)
        {
            var jobs = await _jobUnitOfWork.JobRepository.GetAsync(c => c.Category == category);
            return jobs;
        }

        public async Task<Job> GetJobDetailsAsync(Guid jobId)
        {
            var companyJobDetails = await _jobUnitOfWork.JobRepository.GetAsync(c => c.Id == jobId);
            return companyJobDetails.FirstOrDefault();
        }
    }
}
