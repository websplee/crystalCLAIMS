using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class MedicalPersonnelRepository : EntityBaseRepository<MedicalPersonnel>, IMedicalPersonnelRepository
    {
        public MedicalPersonnelRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}
