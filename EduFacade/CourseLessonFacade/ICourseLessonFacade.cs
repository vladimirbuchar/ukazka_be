using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.CourseLesson;

namespace EduFacade.CourseLessonFacade
{
    public interface ICourseLessonFacade : IBaseFacade
    {
        Result AddCourseLesson(AddCourseLessonDto addCourseLessonDto);
        HashSet<GetAllLessonInCourseDto> GetAllLessonInCourse(Guid courseId);
        void DeleteCourseLesson(Guid courseLessonId);
        Result UpdateCourseLesson(UpdateCourseLessonDto updateCourseLessonDto);
        GetCourseLessonDetailDto GetCourseLessonDetail(Guid courseLessonId);
        void UpdatePositionCourseLesson(UpdatePositionCourseLessonDto updatePositionCourseLesson);
        void ImportCourseLessonFromPowerPoint(ImportCourseLessonFromPowerPointDto importCourseLessonFromPowerPointDto);
    }
}
