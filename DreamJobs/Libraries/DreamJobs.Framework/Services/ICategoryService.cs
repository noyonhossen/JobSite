using DreamJobs.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task UpdateAsync(Category category);
        Task AddAsync(Category category);
    }
}
