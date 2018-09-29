using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class ClaimDrugRepository : EntityBaseRepository<ClaimDrugs>, IClaimDrugRepository
    {
        public ClaimDrugRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
