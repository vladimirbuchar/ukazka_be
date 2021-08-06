using Model.Functions.Certificate;
using System;
using System.Collections.Generic;

namespace EduRepository.CertificateRepository
{
    public interface ICertificateRepository : IBaseRepository
    {
        void AddCertificate(AddCertificate addCertificate);
        HashSet<GetCertificateInOrganization> GetCertificateInOrganization(Guid organizationId);
        void UpdateCertificate(UpdateCertificate updateCertificate);
        GetCertificateDetail GetCertificateDetail(Guid certificateId);
        void SaveUserCertificate(string name, string fileName, Guid userId, DateTime certificateValidTo);
        HashSet<GetMyCertificate> GetMyCertificate(Guid userId);

    }
}
