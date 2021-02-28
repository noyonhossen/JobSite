using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyDetailsAsync(Guid id);
        
    }
}
