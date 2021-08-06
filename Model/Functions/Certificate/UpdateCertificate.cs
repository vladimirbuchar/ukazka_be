using System;

namespace Model.Functions.Certificate
{
    public class UpdateCertificate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public int CertificateValidTo { get; set; }
    }
}
