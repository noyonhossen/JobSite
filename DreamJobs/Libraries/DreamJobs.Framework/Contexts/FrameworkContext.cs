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

            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(pc => new { pc.EmployeeId, pc.SkillId });

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(pc => pc.Employee)
                .WithMany(p => p.EmployeeSkills)
                .HasForeignKey(pc => pc.EmployeeId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(pc => pc.Skill)
                .WithMany(p => p.EmployeeSkills)
                .HasForeignKey(pc => pc.SkillId);

            modelBuilder.Entity<JobSkill>()
                .HasKey(pc => new { pc.JobId, pc.SkillId });

            modelBuilder.Entity<JobSkill>()
                .HasOne(pc => pc.Job)
                .WithMany(p => p.JobSkills)
                .HasForeignKey(pc => pc.JobId);

            modelBuilder.Entity<JobSkill>()
                .HasOne(pc => pc.Skill)
                .WithMany(p => p.JobSkills)
                .HasForeignKey(pc => pc.SkillId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
