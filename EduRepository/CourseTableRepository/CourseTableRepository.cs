using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Answer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.AnswerRepository
{
    public class CourseTableRepository : BaseRepository, ICourseTableRepository
    {
        public CourseTableRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public void UpdateActualTable(Guid courseTermid, string img)
        {
            SaveDataToCache(courseTermid.ToString(), img, DateTime.Now.AddHours(1));
        }
        public string GetActualTable(Guid courseTermid)
        {
            return GetFirstDataFromCache<string>(courseTermid.ToString());
        }
    }
}
