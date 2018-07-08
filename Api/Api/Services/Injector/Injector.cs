using Api.DomainModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Injector
{
    public static class Injector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region "Services"  
            services.AddMvc();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
            return services;
            #endregion
        }
    }
}
