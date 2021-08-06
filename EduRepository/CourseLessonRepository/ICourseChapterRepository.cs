using Model.Functions.CourseLesson;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseLessonRepository
{
    public interface ICourseLessonRepository : IBaseRepository
    {
        Guid AddCourseLesson(AddCourseLesson addCourseLesson);
        HashSet<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId);
        GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId);
        void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson);
        void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson);
    }
}
