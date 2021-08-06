using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;

namespace EduRepository.SendMessageRepository
{
    public interface ISendMessageRepository : IBaseRepository
    {
        void AddSendMessage(AddSendMessage addSendMessage);
        HashSet<GetSendMessageInOrganization> GetSendMessageInOrganization(Guid organizationId);
        void UpdateSendMessage(UpdateSendMessage updateSendMessage);
        GetSendMessageDetail GetSendMessageDetail(Guid sendMessageId);



    }
}
