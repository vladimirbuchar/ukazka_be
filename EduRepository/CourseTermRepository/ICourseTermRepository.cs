using Model.Functions.CourseTerm;
using Model.Functions.User;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseTermRepository
{
    public interface ICourseTermRepository : IBaseRepository
    {
        HashSet<GetAllTermInCourse> GetAllTermInCourse(Guid courseId);
        GetCourseTermDetail GetCourseTermDetail(Guid courseTermId);
        Guid AddCourseTerm(AddCourseTerm addCourseTerm);
        void UpdateCourseTerm(UpdateCourseTerm updateCourseTerm);
        HashSet<GetAllStudentGroupInTerm> GetAllStudentGroupInTerm(Guid courseTermId);
        void AddStudentGroupToTerm(AddStudentGroupToTerm addStudentGroupToTerm);
        void GenerateTimeTable(Guid courseTermId, DateTime date, Guid timeFromId, Guid timeToId, string dayOfWeek, Guid lectorId, Guid classRoomId);
        HashSet<GetTimeTable> GetTimeTable(Guid courseTermId);
        void CancelCourseTerm(Guid courseTermTimeTableId);
        void RestoreCourseTerm(Guid courseTermTimeTableId);
        void SaveStudentAttendance(Guid studentId, Guid timeTableId, Guid courseTermId, bool isActive);
        HashSet<GetStudentAttendance> GetStudentAttendance(Guid courseTermId);
        GetMyAttendance GetMyAttendance(Guid courseStudentId, Guid courseTermDateId);
        HashSet<GetAllTimeInCourseTerm> GetAllTimeInCourseTerm(Guid courseTermId);
        HashSet<GetStudentEvaluation> GetStudentEvaluation(Guid courseTermId);
        void AddStudentEvaluation(AddStudentEvaluation addStudentEvaluation);
    }
}
