using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.CourseLesson;
using WebModel.CourseLessonItem;

namespace EduFacade.CourseLessonItemFacade
{
    public interface ICourseLessonItemFacade : IBaseFacade
    {
        Result AddCourseLessonItem(AddCourseLessonItemDto addCourseLessonItemDto);
        HashSet<GetCourseLessonItemsDto> GetCourseLessonItems(Guid courseLessonId);
        void DeleteCourseLessonItem(Guid courseLessonItemId);
        Result UpdateCourseLessonItem(UpdateCourseLessonItemDto updateCourseLessonItemDto);
        GetCourseLessonItemDetailDto GetCourseLessonItemDetail(Guid courseLessonItemId);
        void UpdatePositionCourseLessonItem(UpdatePositionCourseLessonItemDto updatePositionCourseLesson);
    }
}
