using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade.Convertor
{
    public class SendMessageConvertor : ISendMessageConvertor
    {

        public SendMessageConvertor()
        {

        }

        public HashSet<GetSendMessageInOrganizationDto> ConvertToWebModel(HashSet<GetSendMessageInOrganization> getSendMessageInOrganizations)
        {
            return getSendMessageInOrganizations.Select(x => new GetSendMessageInOrganizationDto()
            {
                Description = "",
                Id = x.Id,
                Name = x.Name
            }).ToHashSet();
        }

        public GetSendMessageDetailDto ConvertToWebModel(GetSendMessageDetail getSendMessageDetail)
        {
            return new GetSendMessageDetailDto()
            {
                Description = "",
                Html = getSendMessageDetail.Html,
                Id = getSendMessageDetail.Id,
                Name = getSendMessageDetail.Name,
                Reply = getSendMessageDetail.Reply,
                SendMessageType = getSendMessageDetail.SendMessageTypeId,

            };
        }

        public AddSendMessage CovertToBussinessEntity(AddSendMessageDto addSendMessageDto)
        {
            return new AddSendMessage()
            {
                Html = addSendMessageDto.Html,
                Name = addSendMessageDto.Name,
                OrganizationId = addSendMessageDto.OrganizationId,
                Reply = addSendMessageDto.Reply,
                SendMessageType = Guid.Parse(addSendMessageDto.SendMessageType)
            };
        }

        public UpdateSendMessage CovertToBussinessEntity(UpdateSendMessageDto updateSendMessageDto)
        {
            return new UpdateSendMessage()
            {
                Html = updateSendMessageDto.Html,
                Id = updateSendMessageDto.Id,
                Name = updateSendMessageDto.Name,
                Reply = updateSendMessageDto.Reply,
                SendMessageType = Guid.Parse(updateSendMessageDto.SendMessageType)
            };
        }
    }
}
