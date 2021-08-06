using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model.Functions.File;
using System;
using System.Collections.Generic;

namespace EduServices.FileUploadService
{
    public interface IFileUploadService : IBaseService
    {
        void FileUpload(Guid objectOwner, IList<IFormFile> files, string afterUploadEvent, string userAccessToken, bool delete);
        void FileDelete(Guid objectId);
        GetFileDetail GetFileDetail(Guid fileId);
        List<PowerPointSlide> LoadPowerPointFile(string parent, string fileName);
        Guid SaveFilePngFile(string img,string directory);
    }
}
