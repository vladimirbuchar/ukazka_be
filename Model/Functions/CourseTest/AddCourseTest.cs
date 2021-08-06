using System;
using System.Collections.Generic;

namespace Model.Functions.CourseTest
{
    public class AddCourseTest
    {
        public AddCourseTest()
        {
            BankOfQuestion = new List<Guid>();
        }
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public List<Guid> BankOfQuestion { get; set; }
        public Guid CourseLessonId { get; set; }
        public int MaxRepetition { get; set; }
    }
}
