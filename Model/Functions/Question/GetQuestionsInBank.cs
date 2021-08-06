using Model.Functions.Answer;
using System;
using System.Collections.Generic;

namespace Model.Functions.Question
{
    public class GetQuestionsInBank : SqlFunction
    {
        public GetQuestionsInBank()
        {
            Answer = new HashSet<GetAnswersInQuestion>();
        }
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public string AnswerMode { get; set; }
        public string BankOfQuestionName { get; set; }
        public bool IsDefault { get; set; }
        public int Position { get; set; }
        public int BankOfQuestionPosition { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public HashSet<GetAnswersInQuestion> Answer { get; set; }
        public string QuestionMode { get; set; }
        public string FileName { get; set; }
        public Guid ObjectOwner { get; set; }
        public Guid QuestionModeId { get; set; }
        public bool IsAutomatic { get; set; }

    }
}
