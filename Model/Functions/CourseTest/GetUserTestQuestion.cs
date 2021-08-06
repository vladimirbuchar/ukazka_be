using System;
using System.Collections.Generic;

namespace Model.Functions.CourseTest
{
    public class GetUserTestQuestion : SqlFunction
    {
        public GetUserTestQuestion()
        {
            Answers = new HashSet<GetUserTestQuestionAnswer>();
        }
        public Guid Id { get; set; }
        public Guid TestQuestionId { get; set; }
        public bool IsTrue { get; set; }
        public string AnswerMode { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public HashSet<GetUserTestQuestionAnswer> Answers { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
        public Guid QuestionModeId { get; set; }
        public string FilePath { get; set; }
        public string QuestionMode { get; set; }
    }
}
