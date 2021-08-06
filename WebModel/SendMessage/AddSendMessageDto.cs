using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class AddSendMessageDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid OrganizationId { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public string SendMessageType { get; set; }
        public string Reply { get; set; }
    }

}
