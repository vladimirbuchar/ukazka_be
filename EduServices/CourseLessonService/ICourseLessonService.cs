using Core.DataTypes;
using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;

namespace EduServices.CourseLessonService
{
    public interface ICourseLessonService : IBaseService
    {
        Guid AddCourseLesson(AddCourseLesson addCourseLesson);
        void DeleteCourseLesson(Guid courseLessonId);
        HashSet<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId);
        GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId);
        void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson);
        void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson);
        void ValidateCourseLessonName(string name, Result result);
    }
}
