using Model.Functions.BankOfQuestion;
using Model.Functions.Certificate;
using System.Collections.Generic;
using WebModel.BankOfQuestion;
using WebModel.Certificate;

namespace EduFacade.BankOfQuestionFacade.Convertor
{
    public interface ICertificateConvertor
    {
        AddCertificate ConvertToBussinessEntity(AddCertificateDto addCertificateDto);
        HashSet<GetCertificateInOrganizationDto> ConvertToWebModel(HashSet<GetCertificateInOrganization> getBankOfQuestionInOrganizations);
        GetBankOfQuestionDetailDto ConvertToWebModel(GetBankOfQuestionDetail getBankOfQuestionDetail);
        UpdateCertificate ConvertToBussinessEntity(UpdateCertificateDto updateCertificateDto);
        HashSet<GetMyCertificateDto> ConvertToWebModel(HashSet<GetMyCertificate> getMyCertificates);
        GetCertificateDetailDto ConvertToWebModel(GetCertificateDetail getCertificateDetail);
    }
}
