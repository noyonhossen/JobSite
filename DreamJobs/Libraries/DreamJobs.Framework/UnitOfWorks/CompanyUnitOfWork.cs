using DreamJobs.Data;
using DreamJobs.Framework.Contexts;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public class CompanyUnitOfWork : UnitOfWork, ICompanyUnitOfWork
    {
        public ICompanyRepository CompanyRepository { get; set; }

        public CompanyUnitOfWork(FrameworkContext context,
            ICompanyRepository companyRepository)
            : base(context)
        {
            CompanyRepository = companyRepository;
        }
    }
}
