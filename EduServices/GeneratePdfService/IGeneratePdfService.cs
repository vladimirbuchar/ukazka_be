using System;

namespace EduServices.GeneratePdfService
{
    public interface IGeneratePdfService : IBaseService
    {
        Guid HtmlToPdfFile(string html);
    }
}
