using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.DomainModels
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signManager;
    


        public AccountRepository(UserManager <AppIdentityUser> userManager,SignInManager<AppIdentityUser>signInManager)
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
        public async Task<bool> Login(LogIn model)
        {
            var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            Console.WriteLine(result);
            if (result.Succeeded) {
                return true;
            }
            return false;
    }
        
        public async void  Logout()
        {
             await _signManager.SignOutAsync();
            
        }


    }
}
