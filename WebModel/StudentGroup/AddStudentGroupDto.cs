using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class AddStudentGroupDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid OrganizationId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

}
