using EduServices.FileUploadService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EduFacade.FileUploadFacade
{
    public class FileUploadFacade : BaseFacade, IFileUploadFacade
    {
        private readonly IFileUploadService _fileUploadService;
        public FileUploadFacade(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public void FileDelete(Guid objectId)
        {
            _fileUploadService.FileDelete(objectId);
        }

        public void FileUpload(Guid objectOwner, IList<IFormFile> files, string afterUploadEvent, string userAccessToken, bool delete)
        {
            _fileUploadService.FileUpload(objectOwner, files, afterUploadEvent, userAccessToken, delete);
        }
    }
}
