using Core.DataTypes;
using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;

namespace EduServices.CourseLessonItemService
{
    public interface ICourseLessonItemService : IBaseService
    {
        Guid AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem);
        void DeleteCourseLessonItem(Guid courseLessonItemId);
        HashSet<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId);
        GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId);
        void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem);
        void ValidateLessonItemName(string name, Result result);
        GetUserCourseItem GetUserCourseItem(Guid courseId, Guid userId);
        void UpdatePositionCourseLessonItem(UpdatePositionCourseLessonItem updatePositionCourseLessonItem);
        GetCourseLessonPowerPointFile GetCourseLessonPowerPointFile(Guid courseLessonItemId);
        void ValidateItemTemplate(Guid templateId, Result result);
    }
}
