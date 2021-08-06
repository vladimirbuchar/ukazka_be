using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Certificate;

namespace EduFacade.CertificateFacade
{
    public interface ICertificateFacade : IBaseFacade
    {
        Result AddCertificate(AddCertificateDto addCertificateDto);
        HashSet<GetCertificateInOrganizationDto> GetCertificateInOrganization(Guid organizatiuonId);
        Result UpdateCertificate(UpdateCertificateDto updateBankOfQuestionDto);
        Result DeleteCertificate(Guid certificateId);
        HashSet<GetMyCertificateDto> GetMyCertificate(Guid userId);
        GetCertificateDetailDto GetCertificateDetail(Guid certificateId);
    }
}
