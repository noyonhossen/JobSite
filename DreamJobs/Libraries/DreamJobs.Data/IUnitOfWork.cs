using System.Threading.Tasks;

namespace DreamJobs.Data
{
    public interface IUnitOfWork
    {
        void Save();

        Task SaveAsync();
    }
}
