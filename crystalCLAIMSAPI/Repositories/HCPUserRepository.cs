using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class HCPUserRepository : EntityBaseRepository<HCPUser>, IHCPUserRepository
    {
        public HCPUserRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
