using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class ClaimServiceProvidedRepository : EntityBaseRepository<ClaimServices>, IClaimServiceProvidedRepository
    {
        public ClaimServiceProvidedRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
