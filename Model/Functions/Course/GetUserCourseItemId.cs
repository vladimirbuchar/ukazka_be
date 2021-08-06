using System;

namespace Model.Functions.Course
{
    public class GetUserCourseItemId : SqlFunction
    {
        public Guid CourseLessonItemId { get; set; }
    }
}
