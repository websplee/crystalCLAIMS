using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class PolicyHolderViewModel
    {
        public string PolicyHolderName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Telephone { get; set; }
        public string Telephone1 { get; set; }
        public int? InsuranceProviderId { get; set; }
        public string PolicyNumber { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }

        public string ProviderName { get; set; }
        public ICollection<MemberViewModel> Members { get; set; }
    }
}
