using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.Models
{
    public class CrystalConfig
    {
        public string StsServerIdentityUrl { get; set; }
        public string AngularClientUrl { get; set; }
        public string AngularClientIdTokenOnlyUrl { get; set; }
    }
}
