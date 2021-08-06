using System;

namespace Model.Functions.Certificate
{
    public class GetMyCertificate : SqlFunction
    {
        public string Name { get; set; }
        public DateTime ActiveFrom { get; set; }
        public string FileName { get; set; }
    }
}
