using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class IPUserRepository : EntityBaseRepository<IPUser>, IIPUSerRepository
    {
        public IPUserRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
