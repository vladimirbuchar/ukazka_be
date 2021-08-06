using System;
using WebModel.Shared;

namespace WebModel.Certificate
{
    public class GetCertificateInOrganizationDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
    }
}
