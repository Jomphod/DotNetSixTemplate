using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Email
{
    public class SendgridEmailProviderOption
    {
        public const string ConfigItem = "SendgridEmailProvider";

        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}