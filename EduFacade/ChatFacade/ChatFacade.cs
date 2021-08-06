using Core.DataTypes;
using EduFacade.AnswerFacade.Convertor;
using EduServices.AnswerService;
using EduServices.CodeBookService;
using Model.Functions.Answer;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Answer;
namespace EduFacade.AnswerFacade
{
    public class ChatFacade : BaseFacade, IChatFacade
    {
        private readonly IChatService _chatService;
        private readonly IChatConvertor _chatConvertor;
        
        public ChatFacade(IChatService chatService, IChatConvertor chatConvertor)
        {
            _chatService = chatService;
            _chatConvertor = chatConvertor;
            
        }

        public Result AddChatItem(AddChatItemDto addChatItemDto)
        {
            if (!string.IsNullOrEmpty(addChatItemDto.Text))
            {
                _chatService.AddChatItem(_chatConvertor.ConvertToBussinessEntity(addChatItemDto));
            }
            return new Result();
        }

        public void DeleteChatItem(Guid id)
        {
            _chatService.DeleteChatItem(id);
        }

        public HashSet<GetAllChatItemDto> GetAllChatItem(Guid courseTermId, Guid userId)
        {
            return _chatConvertor.ConvertToWebModel(_chatService.GetAllChatItem(courseTermId, userId));
        }

        public void UpdateChatItem(UpdateChatItemDto updateChatItemDto)
        {
            _chatService.UpdateChatItem(_chatConvertor.ConvertToBussinessEntity(updateChatItemDto));
        }
    }
}
