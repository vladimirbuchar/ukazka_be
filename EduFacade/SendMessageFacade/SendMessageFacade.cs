using Core.DataTypes;
using EduFacade.SendMessageFacade.Convertor;
using EduServices.CertificateService;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade
{
    public class SendMessageFacade : BaseFacade, ISendMessageFacade
    {
        private readonly ISendMessageConvertor _sendMessageConvertor;
        private readonly ISendMessageService _sendMessageService;
        public SendMessageFacade(ISendMessageService sendMessageService, ISendMessageConvertor sendMessageConvertor)
        {
            _sendMessageConvertor = sendMessageConvertor;
            _sendMessageService = sendMessageService;
        }

        public Result AddSendMessage(AddSendMessageDto addSendMessageDto)
        {
            Result result = new Result();
            _sendMessageService.ValidateName(addSendMessageDto.Name, result);
            Guid sendMessageType = Guid.Empty;
            Guid.TryParse(addSendMessageDto.SendMessageType, out sendMessageType);
            _sendMessageService.ValidateMessageType(sendMessageType, addSendMessageDto.Reply, result);
            if (result.IsOk)
            {
                Model.Functions.SendMessage.AddSendMessage addSendMessage = _sendMessageConvertor.CovertToBussinessEntity(addSendMessageDto);
                _sendMessageService.AddSendMessage(addSendMessage);
            }
            return result;
        }

        public void DeleteSendMessage(Guid sendMessageId)
        {
            _sendMessageService.DeleteSendMessage(sendMessageId);
        }

        public GetSendMessageDetailDto GetSendMessageDetail(Guid sendMessageId)
        {
            return _sendMessageConvertor.ConvertToWebModel(_sendMessageService.GetSendMessageDetail(sendMessageId));
        }

        public HashSet<GetSendMessageInOrganizationDto> GetSendMessageInOrganization(Guid organizationId)
        {
            return _sendMessageConvertor.ConvertToWebModel(_sendMessageService.GetSendMessageInOrganization(organizationId));
        }

        public HashSet<GetSendMessageInOrganizationDto> GetSendMessageInOrganizationEmail(Guid organizationId)
        {
            return _sendMessageConvertor.ConvertToWebModel(_sendMessageService.GetSendMessageInOrganization(organizationId).Where(x => x.SystemIdentificator == SendMessageTypeValue.EMAIL).ToHashSet());
        }


        public Result UpdateSendMessage(UpdateSendMessageDto updateSendMessageDto)
        {
            Result result = new Result();
            Guid sendMessageType = Guid.Empty;
            Guid.TryParse(updateSendMessageDto.SendMessageType, out sendMessageType);
            _sendMessageService.ValidateName(updateSendMessageDto.Name, result);
            _sendMessageService.ValidateMessageType(sendMessageType, updateSendMessageDto.Reply, result);
            if (result.IsOk)
            {
                Model.Functions.SendMessage.UpdateSendMessage updateSendMessage = _sendMessageConvertor.CovertToBussinessEntity(updateSendMessageDto);
                _sendMessageService.UpdateSendMessage(updateSendMessage);
            }

            return result;
        }
    }
}
