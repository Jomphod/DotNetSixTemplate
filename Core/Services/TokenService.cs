using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Email;

namespace Core.Interfaces.Services
{
    public class TokenService : ITokenService
    {
        private readonly IEmailProvider _emailProvider;
        public TokenService(IEmailProvider emailProvider)
        {
            _emailProvider = emailProvider;
        }

        public async Task<string> SendEmailTokenAsync(){
            return await _emailProvider.SendEmailAsync(
                subject: "xxx",
                message: "",
                recepients: new List<string>() { "dummy@mail.com" }
            );
        }
    }
}