using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTerm;

namespace EduFacade.CourseTermFacade
{
    public interface ICourseTermFacade : IBaseFacade
    {
        Result AddCourseTerm(AddCourseTermDto addCourseTermDto, Guid organizationId);
        HashSet<GetAllTermInCourseDto> GetAllTermInCourse(Guid courseId);
        GetCourseTermDetailDto GetCourseTermDetail(Guid courseTermId);
        Result UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto, Guid organizationId, Guid userId);
        void DeleteCourseTerm(Guid courseTermId);
        HashSet<GetTimeTableDto> GetTimeTable(Guid courseTermId);
        void GenerateTimeTable(Guid courseTermId);
        void CancelCourseTerm(Guid courseTermTimeTableId);
        void RestoreCourseTerm(Guid courseTermTimeTableId);
        GetStudentAttendanceDto GetStudentAttendance(Guid courseTermId);
        void SaveStudentAttendance(Guid studentId, Guid timeTableId, Guid courseTermId, bool isActive);
        HashSet<GetStudentEvaluationDto> GetStudentEvaluation(Guid courseTermId);
        void AddStudentEvaluation(AddStudentEvaluationDto addStudentEvaluation);
    }
}
