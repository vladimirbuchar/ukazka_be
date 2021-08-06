using Microsoft.AspNetCore.Http;
using Model.Functions.File;
using System;

namespace EduRepository.FileUploadRepository
{
    public interface IFileUploadRepository : IBaseRepository
    {
        Guid FileUpload(Guid objectOwner, IFormFile file);
        void CreateFileRepository(Guid objectOwner);
        void DeleteAllFiles(Guid objectOwner);
        GetFileDetail GetFileDetail(Guid fileId);

    }
}
