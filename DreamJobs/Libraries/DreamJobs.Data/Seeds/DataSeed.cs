using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DreamJobs.Data.Seeds
{
    public abstract class DataSeed : ISeed
    {
        protected readonly DbContext _context;

        public DataSeed(DbContext context)
        {
            _context = context;
        }

        public async Task MigrateAsync()
        {
            await _context.Database.MigrateAsync();
        }

        public abstract Task SeedAsync();
    }
}
