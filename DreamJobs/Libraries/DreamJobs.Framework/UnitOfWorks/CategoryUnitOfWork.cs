using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public class CategoryUnitOfWork : UnitOfWork, ICategoryUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public CategoryUnitOfWork(FrameworkContext context,
            ICategoryRepository categoryRepository)
            : base(context)
        {
            CategoryRepository = categoryRepository;
        }
    }
}
