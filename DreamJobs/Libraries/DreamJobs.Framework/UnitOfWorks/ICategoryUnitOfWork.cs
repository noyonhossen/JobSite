using DreamJobs.Data;
using DreamJobs.Framework.Repositories;

namespace DreamJobs.Framework.UnitOfWorks
{
    public interface ICategoryUnitOfWork : IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
    }
}
