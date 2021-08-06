using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.File;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
namespace EduRepository.FileUploadRepository
{
    public class FileUploadRepository : BaseRepository, IFileUploadRepository
    {
        private readonly string _fileRepositoryPath;
        public FileUploadRepository(IHostingEnvironment hostingEnvironment, EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
            string projectRootPath = hostingEnvironment.ContentRootPath;
            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}", parent, configuration.GetSection("FileRepository").Value);


        }
        public void CreateFileRepository(Guid objectOwner)
        {
            string path = string.Format("{0}{1}", _fileRepositoryPath, objectOwner);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void DeleteAllFiles(Guid objectOwner)
        {
            CallSqlProcedure("DeleteAllFilesInFileRepository", new List<SqlParameter>()
            {
                {new SqlParameter("@ObjectOwner",objectOwner) }
            });
        }

        public Guid FileUpload(Guid objectOwner, IFormFile file)
        {
            string extesion = Path.GetExtension(file.FileName);
            string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), extesion);
            string filePath = string.Format("{0}{1}/{2}", _fileRepositoryPath, objectOwner, fileName);
            if (File.Exists(filePath))
            {
                return FileUpload(objectOwner, file);
            }

            using FileStream localFile = File.OpenWrite(filePath);
            using Stream uploadedFile = file.OpenReadStream();
            uploadedFile.CopyTo(localFile);
            Guid guid = Guid.Empty;
            CallSqlProcedure("AddFileRepositoryItem", new List<SqlParameter>()
            {
                {new SqlParameter("@ObjectOwner",objectOwner)},
                {new SqlParameter("@FileName",fileName)},
                {new SqlParameter("@OriginalFileName",file.FileName)}
            }, true, ref guid);
            return guid;
        }

        public GetFileDetail GetFileDetail(Guid fileId)
        {
            return CallSqlFunction<GetFileDetail>("GetFileDetail", new List<SqlParameter>()
            {
                {new SqlParameter("@fileId",fileId)}
            }).FirstOrDefault();
        }
    }
}
