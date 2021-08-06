using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseStudent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EduRepository.CourseStudentRepository
{
    public class CourseStudentRepository : BaseRepository, ICourseStudentRepository
    {
        public CourseStudentRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public void AddStudentToCourseTerm(AddStudentToCourseTerm addStudentToCourseTerm)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseTermId", addStudentToCourseTerm.CourseTermId),
                new SqlParameter("@UserId", addStudentToCourseTerm.UserId)
            };
            CallSqlProcedure("AddStudentToCourse", sqlParameters);
        }

        public HashSet<GetAllStudentInCourseTerm> GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return CallSqlFunction<GetAllStudentInCourseTerm>("GetStudentsInTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            });
        }

        public HashSet<GetMyCourse> GetStudentCourse(Guid userId)
        {
            return CallSqlFunction<GetMyCourse>("GetStudentCourse", new List<SqlParameter>()
            {
                new SqlParameter("@userId",userId)
            });
        }
    }
}
