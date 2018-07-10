using Api.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DomainModels
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Register(Register model);
        Task<bool> Login(LogIn model);


    }
}
