using System;

namespace WebModel.CourseTest
{
    public class ShowTestResultAnswerDto
    {
        public Guid Id { get; set; }
        public Guid TestQuestionAnswerId { get; set; }
        public bool IsTrueAnswer { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool UserAnswer { get; set; }
        public bool UserAnswerIsCorrect { get; set; }
        public string FilePath { get; set; }
        public string UserTestImageAnswer { get; set; }
    }
}
