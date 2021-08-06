using Core.DataTypes;
using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;

namespace EduServices.CertificateService
{
    public interface ISendMessageService : IBaseService
    {
        void AddSendMessage(AddSendMessage addSendMessage);
        HashSet<GetSendMessageInOrganization> GetSendMessageInOrganization(Guid organizationId);
        void UpdateSendMessage(UpdateSendMessage updateSendMessage);
        void DeleteSendMessage(Guid sendMessageId);
        GetSendMessageDetail GetSendMessageDetail(Guid sendMessageId);
        void ValidateName(string name, Result result);
        void ValidateMessageType(Guid messageTypeId, string email, Result result);
    }
}
