using Core.DataTypes;
using EduRepository.AnswerRepository;
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
    public class CourseTableService : BaseService, ICourseTableService
    {
        private readonly ICourseTableRepository _courseTableRepository;
        

        public CourseTableService(ICourseTableRepository courseTableRepository)
        {
            _courseTableRepository = courseTableRepository;
        }

        public void UpdateActualTable(Guid courseTermid, string img)
        {
            _courseTableRepository.UpdateActualTable(courseTermid, img);
        }
        public string GetActualTable(Guid courseTermid)
        {
            return _courseTableRepository.GetActualTable(courseTermid);
        }
    }
}
