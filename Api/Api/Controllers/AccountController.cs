using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.DomainModels;
using Api.Models;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [EnableCors("AllowAllHeaders")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountController(IMapper mapper, IAccountRepository accountRepository, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Users()
        {
            //var  user = User.Claims.ElementAt(0);
            var email = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            // var email = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email).Value;
            //// string userEmail = user.ToString();

            //  string[] arr = userEmail.Split(new string[] {"emailaddress:" }, StringSplitOptions.None);
            //string THEEMAIL= arr[1];
            //var currentUser = HttpContext.User;
            //if (currentUser.HasClaim(c => c.Type == ClaimTypes.Email)) {
            //    string Email = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            //userAge = DateTime.Today.Year - birthDate.Year;
            return Ok(email);
           
        }
        [HttpPost]
        public IActionResult  register([FromBody]RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userIdentity = _mapper.Map<Register>(model);
           return Ok( _accountRepository.Register(userIdentity));
        }
        [HttpPost("login")]
        public IActionResult register([FromBody]LogIn model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim("Email", model.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
               claims:claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        //return BadRequest();
    }
}