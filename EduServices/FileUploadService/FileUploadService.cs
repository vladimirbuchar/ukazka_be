using Core.DataTypes;
using EduRepository.FileUploadRepository;
using Integration.HttpClient;
using Integration.PowerPointIntegration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model.Functions.File;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace EduServices.FileUploadService
{
    public class FileUploadService : BaseService, IFileUploadService
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        private readonly IHttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPowerPointIntegration _powerPoint;
        private readonly string _fileRepositoryPath;

        public FileUploadService(IFileUploadRepository fileUploadRepository, IHttpClient httpClient, IHttpContextAccessor httpContextAccessor, IPowerPointIntegration powerPoint, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _fileUploadRepository = fileUploadRepository;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _powerPoint = powerPoint;
            string projectRootPath = hostingEnvironment.ContentRootPath;
            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}", parent, configuration.GetSection("FileRepository").Value);

        }

        public void FileUpload(Guid objectOwner, IList<IFormFile> files, string afterUploadEvent, string userAccessToken,bool delete)
        {
            _fileUploadRepository.CreateFileRepository(objectOwner);
            if (delete)
            {
                _fileUploadRepository.DeleteAllFiles(objectOwner);
            }
            foreach (IFormFile item in files)
            {
                Guid id = _fileUploadRepository.FileUpload(objectOwner, item);
                if (!string.IsNullOrEmpty(afterUploadEvent))
                {
                    string url = string.Format("{0}://{1}{2}", _httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Value, afterUploadEvent);
                    Dictionary<string, string> data = new Dictionary<string, string>
                    {
                        { "FileId", id.ToString() },
                        { "ObjectOwner", objectOwner.ToString() }
                    };
                    _httpClient.SendPostAsync(url, userAccessToken, data);
                }
            }
        }
        public void FileDelete(Guid objectId)
        {
            _fileUploadRepository.DeleteEntity<FileRepository>(objectId);
        }

        public GetFileDetail GetFileDetail(Guid fileId)
        {
            return _fileUploadRepository.GetFileDetail(fileId);
        }

        public List<PowerPointSlide> LoadPowerPointFile(string parent, string fileName)
        {
            return _powerPoint.ConvertToHtmlAsync(parent, fileName).Result;
        }

        public Guid SaveFilePngFile(string img, string directory)
        {
            Guid fileName = Guid.NewGuid();
            string filePath = string.Format("{0}{1}/{2}.png", _fileRepositoryPath, directory, fileName);
            byte[] data = Convert.FromBase64String(img.Replace("data:image/png;base64,",""));
            using (var stream = new MemoryStream(data, 0, data.Length))
            {
                Image image = Image.FromStream(stream);
                image.Save(filePath);
            }
            return fileName;
        }
    }
}
