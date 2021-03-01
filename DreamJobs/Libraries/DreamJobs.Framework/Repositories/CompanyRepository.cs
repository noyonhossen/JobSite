using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public class CompanyRepository : Repository<Company, Guid, FrameworkContext>, ICompanyRepository
    {
        public CompanyRepository(FrameworkContext dbContext) : base(dbContext)
        {

        }
    }
}
