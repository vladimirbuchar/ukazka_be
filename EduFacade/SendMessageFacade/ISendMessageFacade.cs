using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade
{
    public interface ISendMessageFacade : IBaseFacade
    {
        Result AddSendMessage(AddSendMessageDto addSendMessageDto);
        HashSet<GetSendMessageInOrganizationDto> GetSendMessageInOrganization(Guid organizationId);
        HashSet<GetSendMessageInOrganizationDto> GetSendMessageInOrganizationEmail(Guid organizationId);
        Result UpdateSendMessage(UpdateSendMessageDto updateSendMessageDto);
        void DeleteSendMessage(Guid sendMessageId);
        GetSendMessageDetailDto GetSendMessageDetail(Guid sendMessageId);
    }
}
