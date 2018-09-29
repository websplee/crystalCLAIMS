using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.Models
{
    public class EmailSettings
    {
        public string SendGridApiKey { get; set; }
        public string SenderEmailAddress { get; set; }
    }
}
