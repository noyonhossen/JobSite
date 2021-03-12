using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeDetailsAsync(Guid id);
        Task UpdateAsync(Employee employee);
        Task AddAsync(Employee employee);
        Task<int> GetTotalEmployeeAsync();
    }
}
