using Core.DataTypes;
using Core.Extension;
using EduRepository.CodeBookRepository;
using EduRepository.SendMessageRepository;
using Model.Functions.SendMessage;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EduServices.CertificateService
{
    public class SendMessageService : BaseService, ISendMessageService
    {
        private readonly ISendMessageRepository _sendMessageRepository;
        private readonly HashSet<SendMessageType> _sendMessageTypes;
        public SendMessageService(ISendMessageRepository sendMessageRepository, ICodeBookRepository codeBookRepository)
        {
            _sendMessageRepository = sendMessageRepository;
            _sendMessageTypes = codeBookRepository.GetCodeBookItems<SendMessageType>();
        }

        public void AddSendMessage(AddSendMessage addSendMessage)
        {
            _sendMessageRepository.AddSendMessage(addSendMessage);
        }

        public void DeleteSendMessage(Guid sendMessageId)
        {
            _sendMessageRepository.DeleteEntity<Model.Tables.Edu.SendMessage>(sendMessageId);
        }

        public GetSendMessageDetail GetSendMessageDetail(Guid sendMessageId)
        {
            return _sendMessageRepository.GetSendMessageDetail(sendMessageId);
        }

        public HashSet<GetSendMessageInOrganization> GetSendMessageInOrganization(Guid organizationId)
        {
            return _sendMessageRepository.GetSendMessageInOrganization(organizationId);
        }

        public void UpdateSendMessage(UpdateSendMessage updateSendMessage)
        {
            _sendMessageRepository.UpdateSendMessage(updateSendMessage);
        }

        public void ValidateMessageType(Guid messageTypeId, string email, Result result)
        {
            if (messageTypeId == Guid.Empty || _sendMessageTypes.FirstOrDefault(x => x.Id == messageTypeId).IsDefault)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "SEND_MESSAGE", "SELECT_MESSAGE_TYPE"));
            }
            if (_sendMessageTypes.FirstOrDefault(x => x.Id == messageTypeId).SystemIdentificator == SendMessageTypeValue.EMAIL)
            {
                if (string.IsNullOrEmpty(email))
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "SEND_MESSAGE", "REPLY_EMAIL_IS_EMPTY"));
                }
                if (!email.IsValidEmail())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "SEND_MESSAGE", "REPLY_EMAIL_IS_NOT_VALID"));
                }
            }
        }

        public void ValidateName(string name, Result result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "SEND_MESSAGE", "NAME_IS_EMPTY"));
            }
        }
    }
}
