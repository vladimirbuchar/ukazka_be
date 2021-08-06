using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseLessonRepository
{
    public class CourseLessonRepository : BaseRepository, ICourseLessonRepository
    {
        public CourseLessonRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid AddCourseLesson(AddCourseLesson addCourseLesson)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@MaterialId", addCourseLesson.MaterialId),
                new SqlParameter("@BasicInformationName", addCourseLesson.Name),
                new SqlParameter("@BasicInformationDescription", addCourseLesson.Description),
                new SqlParameter("@Type",addCourseLesson.Type),
                new SqlParameter("@PowerPointFile",addCourseLesson.PowerPointFile)
            };
            CallSqlProcedure("AddCourseLesson", sqlParameters, true, ref outGuid);
            return outGuid;
        }

        public void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", updateCourseLesson.Id),
                new SqlParameter("@BasicInformationName", updateCourseLesson.Name),
                new SqlParameter("@BasicInformationDescription", updateCourseLesson.Description)
            };
            CallSqlProcedure("UpdateCourseLesson", sqlParameters);
        }

        public HashSet<GetAllLessonInCourse> GetAllLessonInCourse(Guid materialId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@materialId", materialId)
            };
            return CallSqlFunction<GetAllLessonInCourse>("GetAllLessonInCourse", sqlParameters).OrderBy(x => x.Position).ToHashSet();
        }

        public GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@courseLessonId", courseLessonId)
            };
            return CallSqlFunction<GetCourseLessonDetail>("GetCourseLessonDetail", sqlParameters).FirstOrDefault();
        }

        public void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseLessonId", updatePositionCourseLesson.Id),
                new SqlParameter("@NewPosition", updatePositionCourseLesson.NewPosition)
            };
            CallSqlProcedure("UpdatePositionCourseLesson", sqlParameters);
        }
    }
}
