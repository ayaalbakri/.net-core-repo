using Api.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUnitOfWork : IDisposable
    {
        AppIdentityDbContext Context { get; }
        void Commit();
    }
}
