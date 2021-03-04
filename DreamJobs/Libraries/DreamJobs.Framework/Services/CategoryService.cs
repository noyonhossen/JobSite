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
        
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _categoryUnitOfWork.CategoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            var count = await _categoryUnitOfWork.CategoryRepository.GetCountAsync(x => x.Name == category.Name
                    && x.Id != category.Id);

            if (count > 0)
                throw new InvalidOperationException("Category already exists");

            var existingCategory = _categoryUnitOfWork.CategoryRepository.GetById(category.Id);
            existingCategory.Name = category.Name;
            await _categoryUnitOfWork.SaveAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _categoryUnitOfWork.CategoryRepository.AddAsync(category);
            await _categoryUnitOfWork.SaveAsync();
        }
    }
}
