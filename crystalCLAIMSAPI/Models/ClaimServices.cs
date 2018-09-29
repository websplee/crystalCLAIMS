using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class ClaimServices : IEntityBase
    {
        public int Id { get; set; }
        public int ClaimId { get; set; } // FK from Claim
        public int HCPServiceId { get; set; } // FK from HCP Service

        public virtual Claim Claim { get; set;  }
        public virtual HCPService HCPService { get; set; }
    }
}
