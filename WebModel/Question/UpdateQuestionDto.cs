using System;
using WebModel.Shared;

namespace WebModel.Question
{
    public class UpdateQuestionDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public string UserAccessToken { get; set; }
        public Guid QuestionModeId { get; set; }
    }
}
