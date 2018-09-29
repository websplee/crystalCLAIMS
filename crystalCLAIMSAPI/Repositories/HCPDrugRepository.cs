using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class HCPDrugRepository : EntityBaseRepository<HCPDrug>, IHCPDrugRepository
    {
        public HCPDrugRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
