using DreamJobs.Framework.Entities;
using DreamJobs.Framework.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Framework.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;

        public CategoryService(ICategoryUnitOfWork categoryUnitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
        }

        

        public async Task<IList<Category>> GetAllCategoryAsync()
        {
            return await _categoryUnitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}
