using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class PolicyHolderRespository : EntityBaseRepository<PolicyHolder>, IPolicyHolderRepository
    {
        public PolicyHolderRespository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
