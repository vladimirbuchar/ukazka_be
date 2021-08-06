using System;
using WebModel.Shared;

namespace WebModel.Certificate
{
    public class AddCertificateDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid OrganizationId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public int CertificateValidTo { get; set; }
    }
}
