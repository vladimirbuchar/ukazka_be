using Model.Functions.Answer;
using Model.Functions.Chat;
using System;
using System.Collections.Generic;

namespace EduRepository.AnswerRepository
{
    public interface IChatRepository : IBaseRepository
    {
        void AddChatItem(AddChatItem addChatItem);
        void UpdateChatItem(UpdateChatItem updateChatItem);
        HashSet<GetAllChatItem> GetAllChatItem(Guid courseTermId);

    }
}
