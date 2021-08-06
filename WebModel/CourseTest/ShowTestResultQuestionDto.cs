using System;
using System.Collections.Generic;

namespace WebModel.CourseTest
{
    public class ShowTestResultQuestionDto
    {
        public ShowTestResultQuestionDto()
        {
            UserAnswers = new HashSet<ShowTestResultAnswerDto>();
        }
        public Guid Id { get; set; }
        public Guid TestQuestionId { get; set; }
        public bool IsTrue { get; set; }
        public HashSet<ShowTestResultAnswerDto> UserAnswers { get; set; }
        public string AnswerMode { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
        public Guid QuestionModeId { get; set; }
        public string FilePath { get; set; }
        public string QuestionMode { get; set; }


    }
}
