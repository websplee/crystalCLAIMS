using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class MemberRepository : EntityBaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
