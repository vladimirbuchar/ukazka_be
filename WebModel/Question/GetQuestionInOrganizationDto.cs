using System;
using WebModel.Shared;

namespace WebModel.Question
{
    public class GetQuestionInOrganizationDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid AnswerMode { get; set; }
        public string BankOfQuestionName { get; set; }
        public bool IsDefault { get; set; }
        public Guid BankOfQuestionId { get; set; }
    }
}
