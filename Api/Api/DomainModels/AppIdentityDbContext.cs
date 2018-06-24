using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DomainModels
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser,IdentityRole<Guid>, Guid>
    {
        public AppIdentityDbContext(DbContextOptions options)
              : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
