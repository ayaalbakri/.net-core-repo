using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DomainModels;
using Api.Models;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountController(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Users()
        {
            return Ok();
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
    }
}