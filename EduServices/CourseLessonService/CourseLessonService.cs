using Core.DataTypes;
using EduRepository.CourseLessonRepository;
using Model.Functions.CourseLesson;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseLessonService
{

    public class CourseLessonService : BaseService, ICourseLessonService
    {
        private readonly ICourseLessonRepository _courseLessonRepository;
        public CourseLessonService(ICourseLessonRepository courseLessonRepository)
        {
            _courseLessonRepository = courseLessonRepository;
        }
        public Guid AddCourseLesson(AddCourseLesson addCourseLesson)
        {
            return _courseLessonRepository.AddCourseLesson(addCourseLesson);
        }

        public void UpdatePositionCourseLesson(UpdatePositionCourseLesson updatePositionCourseLesson)
        {
            _courseLessonRepository.UpdatePositionCourseLesson(updatePositionCourseLesson);
        }

        public void DeleteCourseLesson(Guid courseLessonId)
        {
            _courseLessonRepository.DeleteEntity<CourseLesson>(courseLessonId);
        }

        public HashSet<GetAllLessonInCourse> GetAllLessonInCourse(Guid courseId)
        {
            return _courseLessonRepository.GetAllLessonInCourse(courseId);
        }

        public GetCourseLessonDetail GetCourseLessonDetail(Guid courseLessonId)
        {
            return _courseLessonRepository.GetCourseLessonDetail(courseLessonId);
        }

        public void UpdateCourseLesson(UpdateCourseLesson updateCourseLesson)
        {
            _courseLessonRepository.UpdateCourseLesson(updateCourseLesson);
        }

        public void ValidateCourseLessonName(string name, Result result)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_LESSON", "COURSE_LESSON_NAME_IS_EMPTY"));
            }
        }
    }
}
