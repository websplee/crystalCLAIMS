using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class StandardDrugRepository : EntityBaseRepository<StandardDrug>, IStandardDrugRepository
    {
        public StandardDrugRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
