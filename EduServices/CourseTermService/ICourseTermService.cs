using Core.DataTypes;
using Model.Functions.CourseTerm;
using Model.Functions.User;
using System;
using System.Collections.Generic;

namespace EduServices.CourseTermService
{
    public interface ICourseTermService : IBaseService
    {
        /// <summary>
        /// add new term to course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseTerm"></param>
        Guid AddCourseTerm(AddCourseTerm addCourse);

        /// <summary>
        /// update exists trem in course
        /// </summary>
        /// <param name="courseTerm"></param>
        void UpdateCourseTerm(UpdateCourseTerm updateCourse);

        /// <summary>
        /// delete exist term from course
        /// </summary>
        /// <param name="id"></param>
        void DeleteCourseTerm(Guid courseTermId);

        /// <summary>
        /// get all exist term in course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        HashSet<GetAllTermInCourse> GetAllTermInCourse(Guid courseId);
        /// <summary>
        /// get more information about term
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetCourseTermDetail GetCourseTermDetail(Guid courseTermId);
        void ValidateCourseDate(DateTime? activeFrom, DateTime? activeTo, DateTime? registrationFrom, DateTime? registrationTo, Result validate);
        void StudentValidation(int minimumStudent, int maximumStudent, int classRoomCapacity, Result validate);
        HashSet<GetAllStudentGroupInTerm> GetAllStudentGroupInTerm(Guid courseTermId);
        void DeleteStudentGroupFromTerm(Guid id);
        void AddStudentGroupToTerm(AddStudentGroupToTerm addStudentGroupToTerm);
        void GenerateTimeTable(DateTime activeFrom, DateTime activeTo, Guid timeFromId, Guid timeToId, List<bool> days, Guid courseTermId, List<string> lectors, Guid classRoomId);
        HashSet<GetTimeTable> GetTimeTable(Guid courseTermId);
        void DeleteTimeTable(Guid timeTableId);
        void CancelCourseTerm(Guid courseTermTimeTableId);
        void RestoreCourseTerm(Guid courseTermTimeTableId);
        void SaveStudentAttendance(Guid studentId, Guid timeTableId, Guid courseTermId, bool isActive);
        HashSet<GetStudentAttendance> GetStudentAttendance(Guid courseTermId);
        GetMyAttendance GetMyAttendance(Guid courseStudentId,Guid courseTermDateId);
        HashSet<GetAllTimeInCourseTerm> GetAllTimeInCourseTerm(Guid courseTermId);
        HashSet<GetStudentEvaluation> GetStudentEvaluation(Guid courseTermId);
        void AddStudentEvaluation(AddStudentEvaluation addStudentEvaluation);
    }
}

