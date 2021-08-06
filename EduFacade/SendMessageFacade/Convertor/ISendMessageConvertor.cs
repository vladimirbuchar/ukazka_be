using Model.Functions.SendMessage;
using System.Collections.Generic;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade.Convertor
{
    public interface ISendMessageConvertor
    {
        AddSendMessage CovertToBussinessEntity(AddSendMessageDto addSendMessageDto);
        HashSet<GetSendMessageInOrganizationDto> ConvertToWebModel(HashSet<GetSendMessageInOrganization> getSendMessageInOrganizations);
        UpdateSendMessage CovertToBussinessEntity(UpdateSendMessageDto updateSendMessageDto);
        GetSendMessageDetailDto ConvertToWebModel(GetSendMessageDetail getSendMessageDetail);
    }

}
