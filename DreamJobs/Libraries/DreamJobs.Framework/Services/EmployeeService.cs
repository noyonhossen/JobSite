using DreamJobs.Framework.Entities;
using DreamJobs.Framework.UnitOfWorks;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeUnitOfWork _employeeUnitOfWork;

        public EmployeeService(IEmployeeUnitOfWork employeeUnitOfWork)
        {
            _employeeUnitOfWork = employeeUnitOfWork;
        }

        public async Task<Employee> GetEmployeeDetailsAsync(Guid id)
        {
            var employees = await _employeeUnitOfWork.EmployeeRepository.GetAsync(x => x.UserId == id);
            return employees.FirstOrDefault();
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeUnitOfWork.EmployeeRepository.EditAsync(employee);
            await _employeeUnitOfWork.SaveAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _employeeUnitOfWork.EmployeeRepository.AddAsync(employee);
            await _employeeUnitOfWork.SaveAsync();
        }
    }
}
