using System;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class ServiceBase : IServiceBase
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
