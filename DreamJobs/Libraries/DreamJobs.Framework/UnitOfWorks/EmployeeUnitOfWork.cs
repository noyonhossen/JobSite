using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public class EmployeeUnitOfWork : UnitOfWork, IEmployeeUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        public EmployeeUnitOfWork(FrameworkContext context,
            IEmployeeRepository employeeRepository)
            : base(context)
        {
            EmployeeRepository = employeeRepository;
        }
    }
}
