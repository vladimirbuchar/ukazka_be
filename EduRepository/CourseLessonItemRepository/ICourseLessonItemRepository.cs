using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseLessonItemRepository
{
    public interface ICourseLessonItemRepository : IBaseRepository
    {
        Guid AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem);
        HashSet<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId);
        GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId);
        void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem);
        GetUserCourseItem GetUserCourseItem(Guid courseId, Guid userId);
        void UpdatePositionCourseLessonItem(UpdatePositionCourseLessonItem updatePositionCourseLessonItem);
        Guid GetFirstCourseItemId(Guid courseId);
        GetCourseLessonPowerPointFile GetCourseLessonPowerPointFile(Guid courseLessonItemId);
    }
}
