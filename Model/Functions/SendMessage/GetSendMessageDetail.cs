using System;

namespace Model.Functions.SendMessage
{
    public class GetSendMessageDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public Guid SendMessageTypeId { get; set; }
        public string Reply { get; set; }
    }
}
