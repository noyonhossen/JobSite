using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, Guid, FrameworkContext>
    {

    }
}
