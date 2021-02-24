using Autofac;
using DreamJobs.Membership.Contexts;
using DreamJobs.Membership.Entities;
using DreamJobs.Membership.Security;
using DreamJobs.Membership.Services;
using Microsoft.AspNetCore.Authorization;

namespace DreamJobs.Membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionStringName, string migrationAssemblyName)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<MembershipContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<MemberRequirementHandler>().As<IAuthorizationHandler>()
                .SingleInstance();

            builder.RegisterType<CompanyRequirementHandler>().As<IAuthorizationHandler>()
                .SingleInstance();

            builder.RegisterType<UserService>().As<IUserService<ApplicationUser>>()
                .SingleInstance();

            builder.RegisterType<SignInService>().As<ISignInService<ApplicationUser>>()
                .SingleInstance();

            builder.RegisterType<RoleService>().As<IRoleService<ApplicationUser>>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
