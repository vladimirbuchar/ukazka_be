using Core.DataTypes;
using EduRepository.AnswerRepository;
using Model.Functions.Answer;
using Model.Functions.Chat;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.AnswerService
{
    public class ChatService : BaseService, IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public void AddChatItem(AddChatItem addChatItem)
        {
            _chatRepository.AddChatItem(addChatItem);
        }

        public void DeleteChatItem(Guid id)
        {
            _chatRepository.DeleteEntity<Chat>(id);
        }

        public HashSet<GetAllChatItem> GetAllChatItem(Guid courseTermId, Guid userId)
        {
            HashSet<GetAllChatItem> outChat = new HashSet<GetAllChatItem>();
            HashSet <GetAllChatItem> chatItems = _chatRepository.GetAllChatItem(courseTermId).OrderByDescending(x => x.Date).ToHashSet();
            foreach (var item in chatItems)
            {
                item.IsAuthor = item.UserId == userId;
            }
            outChat = chatItems.Where(x => x.ParentId == null || x.ParentId == Guid.Empty).ToHashSet();
            foreach (var item in outChat)
            {
                item.Answers = chatItems.Where(x => x.ParentId == item.Id).OrderByDescending(x=>x.Date).ToHashSet();
            }

            return outChat.OrderByDescending(x => x.Date).ToHashSet();
        }

        public void UpdateChatItem(UpdateChatItem updateChatItem)
        {
            _chatRepository.UpdateChatItem(updateChatItem);
        }
    }
}
