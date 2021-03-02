using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public class EmployeeRepository : Repository<Employee, Guid, FrameworkContext>, IEmployeeRepository
    {
        public EmployeeRepository(FrameworkContext dbContext) : base(dbContext)
        {

        }
    }
}
