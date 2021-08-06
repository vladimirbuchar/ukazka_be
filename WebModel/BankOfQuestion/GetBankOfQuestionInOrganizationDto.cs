using System;
using WebModel.Shared;

namespace WebModel.BankOfQuestion
{
    public class GetBankOfQuestionInOrganizationDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
    }
}
