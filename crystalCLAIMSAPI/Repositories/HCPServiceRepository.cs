using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class HCPServiceRepository : EntityBaseRepository<HCPService>, IHCPServiceRepository
    {
        public HCPServiceRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
