using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class GetSendMessageDetailDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public Guid SendMessageType { get; set; }
        public string Reply { get; set; }
    }
}
