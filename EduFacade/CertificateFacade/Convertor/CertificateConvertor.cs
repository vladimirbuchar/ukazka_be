using Microsoft.Extensions.Configuration;
using Model.Functions.BankOfQuestion;
using Model.Functions.Certificate;
using System.Collections.Generic;
using System.Linq;
using WebModel.BankOfQuestion;
using WebModel.Certificate;


namespace EduFacade.BankOfQuestionFacade.Convertor
{
    public class CertificateConvertor : ICertificateConvertor
    {
        private readonly IConfiguration _configuration;
        public CertificateConvertor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AddCertificate ConvertToBussinessEntity(AddCertificateDto addCertificateDto)
        {
            return new AddCertificate()
            {
                Html = addCertificateDto.Html,
                Name = addCertificateDto.Name,
                OrganizationId = addCertificateDto.OrganizationId,
                CertificateValidTo = addCertificateDto.CertificateValidTo

            };
        }

        public UpdateCertificate ConvertToBussinessEntity(UpdateCertificateDto updateCertificateDto)
        {
            return new UpdateCertificate()
            {
                Html = updateCertificateDto.Html,
                Id = updateCertificateDto.Id,
                Name = updateCertificateDto.Name,
                CertificateValidTo = updateCertificateDto.CertificateValidTo
            };
        }

        public HashSet<GetCertificateInOrganizationDto> ConvertToWebModel(HashSet<GetCertificateInOrganization> getCertificateInOrganizations)
        {
            return getCertificateInOrganizations.Select(item => new GetCertificateInOrganizationDto()
            {
                Description = "",
                Id = item.Id,
                Html = item.Html,
                Name = item.Name
            }).ToHashSet();
        }

        public GetBankOfQuestionDetailDto ConvertToWebModel(GetBankOfQuestionDetail getBankOfQuestionDetail)
        {
            return new GetBankOfQuestionDetailDto()
            {
                Description = getBankOfQuestionDetail.Description,
                Name = getBankOfQuestionDetail.Name,
                Id = getBankOfQuestionDetail.Id,
                IsDefault = getBankOfQuestionDetail.IsDefault

            };
        }

        public HashSet<GetMyCertificateDto> ConvertToWebModel(HashSet<GetMyCertificate> getMyCertificates)
        {
            return getMyCertificates.Select(x => new GetMyCertificateDto()
            {
                ActiveFrom = x.ActiveFrom,
                Description = "",
                FileName = string.Format("{0}certificate/{1}.pdf", _configuration.GetSection("FileServerUrl").Value, x.FileName),
                Name = x.Name
            }).ToHashSet();
        }

        public GetCertificateDetailDto ConvertToWebModel(GetCertificateDetail getCertificateDetail)
        {
            return new GetCertificateDetailDto()
            {
                Description = "",
                Html = getCertificateDetail.Html,
                Id = getCertificateDetail.Id,
                Name = getCertificateDetail.Name,
                CertificateValidTo = getCertificateDetail.CertificateValidTo
            };
        }
    }
}
