using System;

namespace Model.Functions.SendMessage
{
    public class GetSendMessageInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SystemIdentificator { get; set; }
    }

}
