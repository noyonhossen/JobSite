using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public class JobRepository : Repository<Job, Guid, FrameworkContext>, IJobRepository
    {
        public JobRepository(FrameworkContext dbContext) : base(dbContext)
        {

        }
    }
}
