using System;

namespace Model.Functions.CourseLessonItem
{
    public class GetUserCourseItem : SqlFunction
    {
        public Guid CourseLessonItem { get; set; }
        public string ItemType { get; set; }
    }
}
