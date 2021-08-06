using System;

namespace WebModel.Course
{
    public class CourseLessonAnswerDto
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public string FilePath { get; set; }
    }
}
