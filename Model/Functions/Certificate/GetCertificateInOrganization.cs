using System;

namespace Model.Functions.Certificate
{
    public class GetCertificateInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
    }
}
