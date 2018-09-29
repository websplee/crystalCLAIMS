using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class ClaimRepository : EntityBaseRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
