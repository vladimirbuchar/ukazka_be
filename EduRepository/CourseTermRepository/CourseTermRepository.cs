using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseTerm;
using Model.Functions.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseTermRepository
{
    public class CourseTermRepository : BaseRepository, ICourseTermRepository
    {
        public CourseTermRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }


        public HashSet<GetAllTermInCourse> GetAllTermInCourse(Guid courseId)
        {
            return CallSqlFunction<GetAllTermInCourse>("GetTermInCourse", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            });
        }

        public GetCourseTermDetail GetCourseTermDetail(Guid courseTermId)
        {
            return CallSqlFunction<GetCourseTermDetail>("GetCourseTermDetail", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).FirstOrDefault();
        }

        public Guid AddCourseTerm(AddCourseTerm addCourseTerm)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TimeFromId", addCourseTerm.TimeFromId),
                new SqlParameter("@TimeToId", addCourseTerm.TimeToId),
                new SqlParameter("@ActiveFrom", addCourseTerm.ActiveFrom),
                new SqlParameter("@ActiveTo", addCourseTerm.ActiveTo),
                new SqlParameter("@RegistrationFrom", addCourseTerm.RegistrationFrom),
                new SqlParameter("@RegistrationTo", addCourseTerm.RegistrationTo),
                new SqlParameter("@Monday", addCourseTerm.Monday),
                new SqlParameter("@Tuesday", addCourseTerm.Tuesday),
                new SqlParameter("@Wednesday", addCourseTerm.Wednesday),
                new SqlParameter("@Thursday", addCourseTerm.Thursday),
                new SqlParameter("@Friday", addCourseTerm.Friday),
                new SqlParameter("@Saturday", addCourseTerm.Saturday),
                new SqlParameter("@Sunday", addCourseTerm.Sunday),
                new SqlParameter("@ClassRoomId", addCourseTerm.ClassRoomId),
                new SqlParameter("@CourseId", addCourseTerm.CourseId),
                new SqlParameter("@BasicInformationName", addCourseTerm.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", addCourseTerm.BasicInformationDescription),
                new SqlParameter("@CoursePrice", addCourseTerm.CoursePrice),
                new SqlParameter("@CoursePriceSale", addCourseTerm.CoursePriceSale),
                new SqlParameter("@StudentCountMinimumStudent", addCourseTerm.StudentCountMinimumStudent),
                new SqlParameter("@StudentCountMaximumStudent", addCourseTerm.StudentCountMaximumStudent),
                new SqlParameter("@OrganizationStudyHourId", addCourseTerm.OrganizationStudyHourId)
            };
            CallSqlProcedure("CreateCourseTerm", sqlParameters, true, ref outGuid);
            return outGuid;
        }

        public void UpdateCourseTerm(UpdateCourseTerm updateCourseTerm)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TimeFromId", updateCourseTerm.TimeFromId),
                new SqlParameter("@TimeToId", updateCourseTerm.TimeToId),
                new SqlParameter("@ActiveFrom", updateCourseTerm.ActiveFrom),
                new SqlParameter("@ActiveTo", updateCourseTerm.ActiveTo),
                new SqlParameter("@RegistrationFrom", updateCourseTerm.RegistrationFrom),
                new SqlParameter("@RegistrationTo", updateCourseTerm.RegistrationTo),
                new SqlParameter("@Monday", updateCourseTerm.Monday),
                new SqlParameter("@Tuesday", updateCourseTerm.Tuesday),
                new SqlParameter("@Wednesday", updateCourseTerm.Wednesday),
                new SqlParameter("@Thursday", updateCourseTerm.Thursday),
                new SqlParameter("@Friday", updateCourseTerm.Friday),
                new SqlParameter("@Saturday", updateCourseTerm.Saturday),
                new SqlParameter("@Sunday", updateCourseTerm.Sunday),
                new SqlParameter("@ClassRoomId", updateCourseTerm.ClassRoomId),
                new SqlParameter("@Id", updateCourseTerm.Id),
                new SqlParameter("@BasicInformationName", updateCourseTerm.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateCourseTerm.BasicInformationDescription),
                new SqlParameter("@CoursePrice", updateCourseTerm.CoursePrice),
                new SqlParameter("@CoursePriceSale", updateCourseTerm.CoursePriceSale),
                new SqlParameter("@StudentCountMinimumStudent", updateCourseTerm.StudentCountMinimumStudent),
                new SqlParameter("@StudentCountMaximumStudent", updateCourseTerm.StudentCountMaximumStudent),
                new SqlParameter("@OrganizationStudyHourId", updateCourseTerm.OrganizationStudyHourId)
            };
            CallSqlProcedure("UpdateCourseTerm", sqlParameters);
        }

        public HashSet<GetAllStudentGroupInTerm> GetAllStudentGroupInTerm(Guid courseTermId)
        {
            return CallSqlFunction<GetAllStudentGroupInTerm>("GetAllStudentGroupInTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).ToHashSet();
        }

        public void AddStudentGroupToTerm(AddStudentGroupToTerm addStudentGroupToTerm)
        {
            CallSqlProcedure("AddStudentGroupToTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",addStudentGroupToTerm.CourseTermId),
                new SqlParameter("@studentGroupId",addStudentGroupToTerm.StudentGroupId),
            });
        }

        public void GenerateTimeTable(Guid courseTermId, DateTime date, Guid timeFromId, Guid timeToId, string dayOfWeek, Guid lectorId, Guid classRoomId)
        {
            CallSqlProcedure("GenerateTimeTable", new List<SqlParameter>()
            {
                new SqlParameter("@CourseTermId",courseTermId),
                new SqlParameter("@Date",date),
                new SqlParameter("@TimeFromId",timeFromId),
                new SqlParameter("@TimeToId",timeToId),
                new SqlParameter("@DayOfWeek",dayOfWeek),
                new SqlParameter("@CourseLectorId",lectorId),
                new SqlParameter("@ClassRoomId",classRoomId),

            });
        }

        public HashSet<GetTimeTable> GetTimeTable(Guid courseTermId)
        {
            return CallSqlFunction<GetTimeTable>("GetTimeTable", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).OrderBy(x => x.Date).ToHashSet();
        }

        public void CancelCourseTerm(Guid courseTermTimeTableId)
        {
            CallSqlProcedure("CancelCourseTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermTimeTableId",courseTermTimeTableId)
            });
        }

        public void RestoreCourseTerm(Guid courseTermTimeTableId)
        {
            CallSqlProcedure("RestoreCourseTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermTimeTableId",courseTermTimeTableId)
            });
        }

        public void SaveStudentAttendance(Guid studentId, Guid timeTableId, Guid courseTermId, bool isActive)
        {
            CallSqlProcedure("SaveStudentAttendance", new List<SqlParameter>()
            {
                new SqlParameter("@studentId",studentId),
                new SqlParameter("@timeTableId",timeTableId),
                new SqlParameter("@courseTermId",courseTermId),
                new SqlParameter("@isActive",isActive)

            });
        }

        public HashSet<GetStudentAttendance> GetStudentAttendance(Guid courseTermId)
        {
            return CallSqlFunction<GetStudentAttendance>("GetStudentAttendance", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).ToHashSet();
        }

        public GetMyAttendance GetMyAttendance(Guid courseStudentId, Guid courseTermDateId)
        {
            return CallSqlFunction<GetMyAttendance>("GetMyAttendance", new List<SqlParameter>()
            {
                new SqlParameter("@courseStudentId",courseStudentId),
                new SqlParameter("@courseTermDateId",courseTermDateId)
            }).FirstOrDefault();
        }

        public HashSet<GetAllTimeInCourseTerm> GetAllTimeInCourseTerm(Guid courseTermId)
        {
            return CallSqlFunction<GetAllTimeInCourseTerm>("GetAllTimeInCourseTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).ToHashSet();
        }

        public HashSet<GetStudentEvaluation> GetStudentEvaluation(Guid courseTermId)
        {
            return CallSqlFunction<GetStudentEvaluation>("GetStudentEvaluation", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).ToHashSet();
        }

        public void AddStudentEvaluation(AddStudentEvaluation addStudentEvaluation)
        {
            CallSqlProcedure("AddStudentEvaluation", new List<SqlParameter>()
            {
                new SqlParameter("@evaluation",addStudentEvaluation.Evaluation),
                new SqlParameter("@userInOrganizationId",addStudentEvaluation.UserInOrganizationId),
                new SqlParameter("@courseTermId",addStudentEvaluation.CourseTermId),
            });
        }
    }
}
