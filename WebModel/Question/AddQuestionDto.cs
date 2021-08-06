using System;
using WebModel.Shared;

namespace WebModel.Question
{
    public class AddQuestionDto : BaseDto, IBaseDtoWithUserAccessToken, IValidate
    {
        public string Question { get; set; } = "";
        public Guid AnswerModeId { get; set; }
        public Guid BankOfQUestionId { get; set; }
        public string UserAccessToken { get; set; }
        public bool Validate { get; set; } = true;
        public Guid QuestionModeId { get; set; }
    }
}
