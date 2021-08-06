using System;
using WebModel.Shared;

namespace WebModel.Question
{
    public class GetQuestionDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public Guid QuestionModeId { get; set; }
        public Guid FileId { get; set; }
        public string OriginalFileName { get; set; }
    }
}
