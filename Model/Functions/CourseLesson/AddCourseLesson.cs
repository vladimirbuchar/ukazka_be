using System;

namespace Model.Functions.CourseLesson
{
    public class AddCourseLesson
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MaterialId { get; set; }
        public string Type { get; set; }
        public string PowerPointFile { get; set; } = "";
    }
}
