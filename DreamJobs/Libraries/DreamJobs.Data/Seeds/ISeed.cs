using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Data.Seeds
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}
