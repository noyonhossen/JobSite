using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid, FrameworkContext>
    {

    }
}
