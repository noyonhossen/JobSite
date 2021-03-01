using DreamJobs.Framework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamJobs.Framework.Contexts
{
    public class FrameworkContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many relationship
            modelBuilder.Entity<Company>()
                .HasMany(j => j.Jobs)
                .WithOne(c => c.Company);

            //many to many relationship
            modelBuilder.Entity<JobSkill>()
                .HasKey(js => new { js.JobId, js.SkillId });

            modelBuilder.Entity<JobSkill>()
                .HasOne(s => s.Job)
                .WithMany(js => js.JobSkills)
                .HasForeignKey(j => j.JobId);

            modelBuilder.Entity<JobSkill>()
                .HasOne(s => s.Skill)
                .WithMany(js => js.JobSkills)
                .HasForeignKey(j => j.SkillId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }

    }
}
