using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Email;
using Microsoft.Extensions.Options;

namespace Infra.Email
{
    public class SendgridEmailProvider : IEmailProvider
    {
        protected readonly SendgridEmailProviderOption _options;
        public SendgridEmailProvider(IOptions<SendgridEmailProviderOption> options)
        {
            this._options = options.Value;
        }

        public async Task<string> SendEmailAsync(string subject, string message, List<string> recepients){

            string sendingResult = "";

            await Task.Run(() => {
                sendingResult = $"Email Provider: !! SENDGRID - SMTP !! {Environment.NewLine}" +
                $"Host: {_options.Host} {Environment.NewLine}" +
                $"UserName: {_options.UserName} {Environment.NewLine}" +
                $"Password: {_options.Password} {Environment.NewLine}" +
                $"Subject: {subject} {Environment.NewLine}" +
                $"Message: {message} {Environment.NewLine}" +
                $"Recepients Provider: {String.Join(", ", recepients)}";
            });

            return sendingResult;
        }
    }
}