using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DomainModels;

namespace Api.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppIdentityDbContext Context { get; }

        // public AppIdentityDbContext Context { get; }

        public UnitOfWork(AppIdentityDbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }

      
    }
}
