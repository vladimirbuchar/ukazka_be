using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class GetSendMessageInOrganizationDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
