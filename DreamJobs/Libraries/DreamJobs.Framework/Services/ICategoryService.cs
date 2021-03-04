using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllCategoryAsync();
    }
}
