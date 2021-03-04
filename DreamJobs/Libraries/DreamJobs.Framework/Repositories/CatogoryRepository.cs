using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public class CategoryRepository : Repository<Category, Guid, FrameworkContext>, ICategoryRepository
    {
        public CategoryRepository(FrameworkContext dbContext) : base(dbContext)
        {

        }
    }
}
