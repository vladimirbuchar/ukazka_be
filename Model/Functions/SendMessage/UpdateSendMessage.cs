using System;

namespace Model.Functions.SendMessage
{
    public class AddSendMessage
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageType { get; set; }
        public string Reply { get; set; }
    }

}
