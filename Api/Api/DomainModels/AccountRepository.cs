using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.DomainModels
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signManager;

        public AccountRepository(UserManager <AppIdentityUser> userManager,SignInManager<AppIdentityUser>signInManager )
        {
            _userManager = userManager;
            _signManager = signInManager;
        }
        public async Task<IdentityResult> Register(Register model)
        {
            var user = new AppIdentityUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
             IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            return result;

        }
    }
}
