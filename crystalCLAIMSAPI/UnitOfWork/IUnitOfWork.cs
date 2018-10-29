using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IClaimDiagnosisRepository ClaimDiagnoses { get; }
        IClaimDoctorRepository ClaimDoctors { get; }
        IClaimDrugRepository ClaimDrugs { get; }
        IClaimRepository Claims { get; }
        IClaimServiceProvidedRepository ClaimServicesProvided { get; }
        IDistrictRepository Districts { get; }
        IHCPDiagnosisRepository HCPDiagnoses { get; }
        IHCPDoctorRepository HCPDoctors { get; }
        IHCPDrugRepository HCPDrugs { get; }
        IHCPServiceRepository HCPServices { get; }
        IHCPUserRepository HCPUsers { get; }
        IHealthcareProviderRepository HealthcareProviders { get; }
        IInsuranceProviderRepository InsuranceProviders { get; }
        IIPUSerRepository IPUsers { get; }
        IMedicalPersonnelRepository MedicalPersonnel { get; }
        IMemberRepository Members { get; }
        IPolicyHolderRepository PolicyHolders { get; }
        IProvinceRepository Provinces { get; }
        IStandardDiagnosisRepository StandardDiagnoses { get; }
        IStandardDrugRepository StandardDrugs { get; }
        IStandardServiceProvidedRepository StandardServiceProvided { get; }

        int SaveChanges();
    }
}
