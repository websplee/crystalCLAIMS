using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Repositories;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly CrystalCLAIMSDbContext _context;

        IClaimDiagnosisRepository _claimDiagnoses;
        IClaimDoctorRepository _claimDoctors;
        IClaimDrugRepository _claimDrugs;
        IClaimRepository _claims;
        IClaimServiceProvidedRepository _claimServicesProvided;
        IDistrictRepository _districts;
        IHCPDiagnosisRepository _hCPDiagnoses;
        IHCPDoctorRepository _hCPDoctors;
        IHCPDrugRepository _hCPDrugs;
        IHCPServiceRepository _hCPServices;
        IHCPUserRepository _hCPUsers;
        IHealthcareProviderRepository _healthcareProviders;
        IInsuranceProviderRepository _insuranceProviders;
        IIPUSerRepository _iPUsers;
        IMedicalPersonnelRepository _medicalPersonnel;
        IMemberRepository _members;
        IPolicyHolderRepository _policyHolders;
        IProvinceRepository _provinces;
        IStandardDiagnosisRepository _standardDiagnoses;
        IStandardDrugRepository _standardDrugs;
        IStandardServiceProvidedRepository _standardServiceProvided;

        public UnitOfWork(CrystalCLAIMSDbContext context)
        {
            _context = context;
        }

        public IClaimDiagnosisRepository ClaimDiagnoses
        {
            get
            {
                if (_claimDiagnoses == null)
                    _claimDiagnoses = new ClaimDiagnosisRepository(_context);

                return _claimDiagnoses;
            }
        }

        public IClaimDoctorRepository ClaimDoctors
        {
            get
            {
                if (_claimDoctors == null)
                    _claimDoctors = new ClaimDoctorRepository(_context);

                return _claimDoctors;
            }
        }

        public IClaimDrugRepository ClaimDrugs
        {
            get
            {
                if (_claimDrugs == null)
                    _claimDrugs = new ClaimDrugRepository(_context);

                return _claimDrugs;
            }
        }

        public IClaimRepository Claims
        {
            get
            {
                if (_claims == null)
                    _claims = new ClaimRepository(_context);

                return _claims;
            }
        }

        public IClaimServiceProvidedRepository ClaimServicesProvided
        {
            get
            {
                if (_claimServicesProvided == null)
                    _claimServicesProvided = new ClaimServiceProvidedRepository(_context);

                return _claimServicesProvided;
            }
        }

        public IDistrictRepository Districts
        {
            get
            {
                if (_districts == null)
                    _districts = new DistrictRepository(_context);

                return _districts;
            }
        }

        public IHCPDiagnosisRepository HCPDiagnoses
        {
            get
            {
                if (_hCPDiagnoses == null)
                    _hCPDiagnoses = new HCPDiagnosisRepository(_context);

                return _hCPDiagnoses;
            }
        }

        public IHCPDoctorRepository HCPDoctors
        {
            get
            {
                if (_hCPDoctors == null)
                    _hCPDoctors = new HCPDoctorRepository(_context);

                return _hCPDoctors;
            }
        }

        public IHCPDrugRepository HCPDrugs
        {
            get
            {
                if (_hCPDrugs == null)
                    _hCPDrugs = new HCPDrugRepository(_context);

                return _hCPDrugs;
            }
        }

        public IHCPServiceRepository HCPServices
        {
            get
            {
                if (_hCPServices == null)
                    _hCPServices = new HCPServiceRepository(_context);

                return _hCPServices;
            }
        }

        public IHCPUserRepository HCPUsers
        {
            get
            {
                if (_hCPUsers == null)
                    _hCPUsers = new HCPUserRepository(_context);

                return _hCPUsers;
            }
        }

        public IHealthcareProviderRepository HealthcareProviders
        {
            get
            {
                if (_healthcareProviders == null)
                    _healthcareProviders = new HealthcareProviderRepository(_context);

                return _healthcareProviders;
            }
        }

        public IInsuranceProviderRepository InsuranceProviders
        {
            get
            {
                if (_insuranceProviders == null)
                    _insuranceProviders = new InsuranceProviderRepository(_context);

                return _insuranceProviders;
            }
        }

        public IIPUSerRepository IPUsers
        {
            get
            {
                if (_iPUsers == null)
                    _iPUsers = new IPUserRepository(_context);

                return _iPUsers;
            }
        }

        public IMedicalPersonnelRepository MedicalPersonnel
        {
            get
            {
                if (_medicalPersonnel == null)
                    _medicalPersonnel = new MedicalPersonnelRepository(_context);

                return _medicalPersonnel;
            }
        }

        public IMemberRepository Members
        {
            get
            {
                if (_members == null)
                    _members = new MemberRepository(_context);

                return _members;
            }
        }

        public IPolicyHolderRepository PolicyHolders
        {
            get
            {
                if (_policyHolders == null)
                    _policyHolders = new PolicyHolderRespository(_context);

                return _policyHolders;
            }
        }

        public IProvinceRepository Provinces
        {
            get
            {
                if (_provinces == null)
                    _provinces = new ProvinceRepository(_context);

                return _provinces;
            }
        }

        public IStandardDiagnosisRepository StandardDiagnoses
        {
            get
            {
                if (_standardDiagnoses == null)
                    _standardDiagnoses = new StandardDiagnosisRepository(_context);

                return _standardDiagnoses;
            }
        }

        public IStandardDrugRepository StandardDrugs
        {
            get
            {
                if (_standardDrugs == null)
                    _standardDrugs = new StandardDrugRepository(_context);

                return _standardDrugs;
            }
        }

        public IStandardServiceProvidedRepository StandardServiceProvided
        {
            get
            {
                if (_standardServiceProvided == null)
                    _standardServiceProvided = new StandardServiceProvidedRepository(_context);

                return _standardServiceProvided;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
