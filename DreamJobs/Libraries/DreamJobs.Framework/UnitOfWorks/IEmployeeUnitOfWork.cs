using DreamJobs.Data;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public interface IEmployeeUnitOfWork : IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; set; }
    }
}
