using Core.DataTypes;
using EduRepository.CertificateRepository;
using Model.Functions.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CertificateService
{
    public class CertificateService : BaseService, ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        public CertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }
        public void AddCertificate(AddCertificate addCertificate)
        {
            _certificateRepository.AddCertificate(addCertificate);
        }

        public void DeleteCertificate(Guid certificateId)
        {
            _certificateRepository.DeleteEntity<Model.Tables.Edu.Certificate>(certificateId);
        }

        public GetCertificateDetail GetCertificateDetail(Guid certificateId)
        {
            return _certificateRepository.GetCertificateDetail(certificateId);
        }

        public HashSet<GetCertificateInOrganization> GetCertificateInOrganization(Guid organizationId)
        {
            return _certificateRepository.GetCertificateInOrganization(organizationId);
        }

        public HashSet<GetMyCertificate> GetMyCertificate(Guid userId)
        {
            return _certificateRepository.GetMyCertificate(userId).OrderByDescending(x => x.ActiveFrom).ToHashSet();
        }

        public void SaveUserCertificate(string name, string fileName, Guid userId, DateTime certificateValidTo)
        {
            _certificateRepository.SaveUserCertificate(name, fileName, userId, certificateValidTo);
        }

        public void UpdateCertificate(UpdateCertificate updateCertificate)
        {
            _certificateRepository.UpdateCertificate(updateCertificate);
        }

        public void ValidateName(string name, Result result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "CERTIFICATE", "NAME_IS_EMPTY"));
            }
        }
    }
}
