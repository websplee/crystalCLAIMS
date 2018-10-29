using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class ProvinceViewModel
    {
        public string ProvinceName { get; set; }

        public ICollection<DistrictViewModel> Districts { get; set; }
    }
}
