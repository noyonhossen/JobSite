using DreamJobs.Data;
using DreamJobs.Framework.Repositories;

namespace DreamJobs.Framework.UnitOfWorks
{
    public interface ISkillUnitOfWork : IUnitOfWork
    {
        ISkillRepository SkillRepository { get; set; }
    }
}
