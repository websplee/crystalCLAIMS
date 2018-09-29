using System.Security.Cryptography.X509Certificates;

namespace crystalCLAIMSAPI.Services.Certificates
{
    public interface ICertificateService
    {
        X509Certificate2 GetCertificateFromKeyVault(string vaultCertificateName);
    }
}
