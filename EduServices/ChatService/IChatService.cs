using Core.DataTypes;
using Model.Functions.Answer;
using Model.Functions.Chat;
using System;
using System.Collections.Generic;

namespace EduServices.AnswerService
{
    public interface IChatService : IBaseService
    {
        void AddChatItem(AddChatItem addChatItem);
        void UpdateChatItem(UpdateChatItem updateChatItem);
        HashSet<GetAllChatItem> GetAllChatItem(Guid courseTermId, Guid userId);
        void DeleteChatItem(Guid id);

    }
}
