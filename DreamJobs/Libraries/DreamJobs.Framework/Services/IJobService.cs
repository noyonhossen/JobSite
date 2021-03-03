using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public interface IJobService
    {
        //Task<Job> GetJobDetailsAsync(Guid id);
        //Task UpdateAsync(Job job);
        Task AddAsync(Job job);
        Task<IList<Job>> GetCompanyAllJobAsync(Company companyInfo);
        Task<IList<Job>> GetJobsByCategoryAsync(string category);
        Task<Job> GetJobDetailsAsync(Guid jobId);
    }
}
