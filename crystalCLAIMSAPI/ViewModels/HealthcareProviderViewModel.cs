using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class HealthcareProviderViewModel
    {
        public string ProviderName { get; set; }
        public string ProviderCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public int DistrictId { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Status { get; set; }

        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
    }
}
