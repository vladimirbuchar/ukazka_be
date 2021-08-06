using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Answer;

namespace EduFacade.AnswerFacade
{
    public interface IChatFacade : IBaseFacade
    {
        Result AddChatItem(AddChatItemDto addChatItemDto);
        void UpdateChatItem(UpdateChatItemDto updateChatItemDto);
        HashSet<GetAllChatItemDto> GetAllChatItem(Guid courseTermId, Guid userId);
        void DeleteChatItem(Guid id);
    }
}

