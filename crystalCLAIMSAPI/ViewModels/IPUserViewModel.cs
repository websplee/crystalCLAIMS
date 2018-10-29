using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class IPUserViewModel
    {

        public string AspNetUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int InsuranceProviderId { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }

        public string ProviderName { get; set; }
    }
}
