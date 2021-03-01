using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public class JobUnitOfWork : UnitOfWork, IJobUnitOfWork
    {
        public IJobRepository JobRepository { get; set; }

        public JobUnitOfWork(FrameworkContext context,
            IJobRepository jobRepository)
            : base(context)
        {
            JobRepository = jobRepository;
        }
    }
}
