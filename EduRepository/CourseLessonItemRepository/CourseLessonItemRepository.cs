using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseLessonItemRepository
{
    public class CourseLessonItemRepository : BaseRepository, ICourseLessonItemRepository
    {
        public CourseLessonItemRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", addCourseLessonItem.CourseLessonId),
                new SqlParameter("@BasicInformationName", addCourseLessonItem.Name),
                new SqlParameter("@BasicInformationDescription", addCourseLessonItem.Description),
                new SqlParameter("@Html", addCourseLessonItem.Html),
                new SqlParameter("@TemplateId", addCourseLessonItem.TemplateId),
                new SqlParameter("@Youtube",addCourseLessonItem.Youtube)
            };
            CallSqlProcedure("AddCourseLessonItem", sqlParameters, true, ref outGuid);
            return outGuid;
        }

        public void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonItemId", updateCourseLessonItem.CourseLessonItemId),
                new SqlParameter("@BasicInformationName", updateCourseLessonItem.Name),
                new SqlParameter("@BasicInformationDescription", updateCourseLessonItem.Description),
                new SqlParameter("@Html", updateCourseLessonItem.Html),
                new SqlParameter("@Youtube",updateCourseLessonItem.Youtube),
                new SqlParameter("@TemplateId", updateCourseLessonItem.TemplateId)
            };
            CallSqlProcedure("UpdateCourseLessonItem", sqlParameters);
        }

        public HashSet<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", courseLessonId)
            };
            return CallSqlFunction<GetCourseLessonItems>("GetCourseLessonItems", sqlParameters).OrderBy(x => x.Position).ToHashSet();
        }

        public GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonItemId", courseLessonItemId)
            };
            return CallSqlFunction<GetCourseLessonItemDetail>("GetCourseLessonItemDetail", sqlParameters).FirstOrDefault();
        }

        public GetUserCourseItem GetUserCourseItem(Guid courseId, Guid userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@CouurseId", courseId)
            };
            return CallSqlFunction<GetUserCourseItem>("GetUserCourseBrowse", parameters).FirstOrDefault();
        }

        public void UpdatePositionCourseLessonItem(UpdatePositionCourseLessonItem updatePositionCourseLessonItem)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonItemId", updatePositionCourseLessonItem.Id),
                new SqlParameter("@NewPosition", updatePositionCourseLessonItem.NewPosition)
            };
            CallSqlProcedure("UpdatePositionCourseLessonItem", sqlParameters);
        }

        public Guid GetFirstCourseItemId(Guid courseId)
        {
            return Guid.Empty;
        }

        public GetCourseLessonPowerPointFile GetCourseLessonPowerPointFile(Guid courseLessonItemId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", courseLessonItemId)
            };
            return CallSqlFunction<GetCourseLessonPowerPointFile>("GetCourseLessonPowerPointFile", sqlParameters).FirstOrDefault();
        }
    }
}
