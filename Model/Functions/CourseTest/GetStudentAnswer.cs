using System;

namespace Model.Functions.CourseTest
{
    public class GetStudentAnswer : SqlFunction
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public bool UserAnswer { get; set; }
        public string UserTestAnswer { get; set; }
        public bool UserAnswerIsCorrect { get; set; }
        public string FilePath { get; set; }
        public Guid TestQuestionAnswerId { get; set; }
        public string UserTestImageAnswer { get; set; }

    }
}
