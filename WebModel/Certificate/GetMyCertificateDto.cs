using System;
using WebModel.Shared;

namespace WebModel.Certificate
{
    public class GetMyCertificateDto : IBasicInformationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActiveFrom { get; set; }
        public string FileName { get; set; }
    }
}
