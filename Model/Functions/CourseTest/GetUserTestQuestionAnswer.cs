using System;

namespace Model.Functions.CourseTest
{
    public class GetUserTestQuestionAnswer : SqlFunction
    {
        public Guid Id { get; set; }
        public Guid TestQuestionAnswerId { get; set; }
        public bool IsTrue { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool UserAnswer { get; set; }
        public bool UserAnswerIsCorrect { get; set; }
        public string FilePath { get; set; }
        public string UserTestImageAnswer { get; set; }
    }
}
