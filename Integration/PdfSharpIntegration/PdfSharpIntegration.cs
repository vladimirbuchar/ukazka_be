using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Integration.PdfSharpIntegration
{
    public class PdfSharpIntegration : IPdfSharpIntegration
    {
        private readonly string _fileRepositoryPath;
        public PdfSharpIntegration(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            string projectRootPath = hostingEnvironment.ContentRootPath;
            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}{2}", parent, configuration.GetSection("FileRepository").Value, "certificate/");
        }
        public Guid HtmlToPdfFile(string html)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
            Guid pdfName = Guid.NewGuid();
            pdf.Save(string.Format("{0}{1}.pdf", _fileRepositoryPath, pdfName));
            return pdfName;


        }
    }
}
