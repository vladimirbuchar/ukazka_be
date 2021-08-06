using System;
using WebModel.Shared;

namespace WebModel.BankOfQuestion
{
    public class AddBankOfQuestionDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid OrganizationId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
