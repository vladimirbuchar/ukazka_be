using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EduFacade.FileUploadFacade
{
    public interface IFileUploadFacade : IBaseFacade
    {
        void FileUpload(Guid objectOwner, IList<IFormFile> files, string afterUploadEvent, string userAccessToken, bool delete);
        void FileDelete(Guid objectId);
    }
}
