using DreamJobs.Data;
using DreamJobs.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJobs.Framework.UnitOfWorks
{
    public interface ICompanyUnitOfWork : IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; set; }
    }
}
