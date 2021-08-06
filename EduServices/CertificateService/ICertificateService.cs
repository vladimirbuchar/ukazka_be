using Core.DataTypes;
using Model.Functions.Certificate;
using System;
using System.Collections.Generic;

namespace EduServices.CertificateService
{
    public interface ICertificateService : IBaseService
    {
        void AddCertificate(AddCertificate addCertificate);
        void ValidateName(string name, Result result);
        HashSet<GetCertificateInOrganization> GetCertificateInOrganization(Guid organizationId);
        void UpdateCertificate(UpdateCertificate updateCertificate);
        void DeleteCertificate(Guid certificateId);
        GetCertificateDetail GetCertificateDetail(Guid certificateId);
        void SaveUserCertificate(string name, string fileName, Guid userId, DateTime certificateValidTo);
        HashSet<GetMyCertificate> GetMyCertificate(Guid userId);
    }
}
