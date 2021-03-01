using Autofac;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Repositories;
using DreamJobs.Framework.Services;
using DreamJobs.Framework.UnitOfWorks;
using System;

namespace DreamJobs.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionStringName, string migrationAssemblyName)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyUnitOfWork>().As<ICompanyUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyService>().As<ICompanyService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JobRepository>().As<IJobRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JobUnitOfWork>().As<IJobUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JobService>().As<IJobService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
