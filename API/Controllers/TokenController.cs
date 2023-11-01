using System.Reflection.PortableExecutable;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            this._tokenService = tokenService;
        }

        [HttpGet(Name = "SendToken")]
        public async Task<string> SendEmailTokenAsync(){
            return await this._tokenService.SendEmailTokenAsync();
        }
    }
}