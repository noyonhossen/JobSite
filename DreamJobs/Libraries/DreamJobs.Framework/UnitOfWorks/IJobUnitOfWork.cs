using DreamJobs.Data;
using DreamJobs.Framework.Repositories;

namespace DreamJobs.Framework.UnitOfWorks
{
    public interface IJobUnitOfWork : IUnitOfWork
    {
        IJobRepository JobRepository { get; set; }
    }
}
