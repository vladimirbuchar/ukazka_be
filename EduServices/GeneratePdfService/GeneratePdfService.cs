using Integration.PdfSharpIntegration;
using System;

namespace EduServices.GeneratePdfService
{
    public class GeneratePdfService : BaseService, IGeneratePdfService
    {
        private readonly IPdfSharpIntegration _pdfSharpIntegration;
        public GeneratePdfService(IPdfSharpIntegration pdfSharpIntegration)
        {
            _pdfSharpIntegration = pdfSharpIntegration;
        }

        public Guid HtmlToPdfFile(string html)
        {
            return _pdfSharpIntegration.HtmlToPdfFile(html);
        }
    }
}
