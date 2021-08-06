using System;
using System.Collections.Generic;

namespace Model.Functions.CourseTest
{
    public class GetStudentQuestion : SqlFunction
    {
        public GetStudentQuestion()
        {
            Answers = new HashSet<GetStudentQuestionAnswer>();
        }

        public Guid Id { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public bool IsTrue { get; set; }
        public string AnswerMode { get; set; }
        public HashSet<GetStudentQuestionAnswer> Answers { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
        public Guid QuestionModeId { get; set; }
        public string FilePath { get; set; }
        public Guid TestQuestionId { get; set; }
        public string QuestionMode { get; set; }

    }
}
