using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Email
{
    public class MailGunEmailProviderOption
    {
        public const string ConfigItem = "MailGunEmailProvider";

        public string APIURL { get; set; }
        public string APIKey { get; set; }
    }
}