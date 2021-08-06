using System;

namespace Model.Functions.CourseTest
{
    public class GetStudentQuestionAnswer : SqlFunction
    {
        public Guid Id { get; set; }
        public bool UserAnswer { get; set; }
        public string Text { get; set; }
        public Guid AnswerId { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }

    }
}
