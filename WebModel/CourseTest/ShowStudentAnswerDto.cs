using System;
using System.Collections.Generic;

namespace WebModel.CourseTest
{
    public class ShowStudentAnswerDto
    {
        public ShowStudentAnswerDto()
        {
            Answer = new HashSet<StudentAswerResult>();
        }
        public Guid Id { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public bool IsTrue { get; set; }
        public string AnswerMode { get; set; }
        public HashSet<StudentAswerResult> Answer { get; set; }

    }
    public class StudentAswerResult
    {
        public Guid Id { get; set; }
        public bool UserAnswer { get; set; }
        public string Text { get; set; }
        public Guid AnswerId { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
    }

}
