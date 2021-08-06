using Core.Extension;
using Model.Functions.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Answer;

namespace EduFacade.AnswerFacade.Convertor
{
    public class ChatConvertor : IChatConvertor
    {

        public ChatConvertor()
        {

        }

        public AddChatItem ConvertToBussinessEntity(AddChatItemDto addChatItemDto)
        {
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(addChatItemDto.ParentId))
            {
                parentId = Guid.Parse(addChatItemDto.ParentId);
            }
            return new AddChatItem()
            {
                CourseTermId = addChatItemDto.CourseTermId,
                ParentId = parentId,
                Text = addChatItemDto.Text,
                UserId = addChatItemDto.UserId
            };
        }

        public UpdateChatItem ConvertToBussinessEntity(UpdateChatItemDto updateChatItemDto)
        {
            return new UpdateChatItem()
            {
                Id = updateChatItemDto.Id,
                Text = updateChatItemDto.Text
            };
        }

        public HashSet<GetAllChatItemDto> ConvertToWebModel(HashSet<GetAllChatItem> getAllChatItems)
        {
            return getAllChatItems.Select(x => new GetAllChatItemDto()
            {
                Id = x.Id,
                Text = x.Text,
                ParentId = x.ParentId,
                UserId = x.UserId,
                IsAvatarUrl = string.IsNullOrEmpty(x.AvatarUrl) ? false : x.AvatarUrl.IsValidUri(),
                Avatar = x.AvatarUrl == null ? string.Format("{0}{1}", x.FirstName.FirstOrDefault(), x.LastName.FirstOrDefault()) : (x.AvatarUrl.IsValidUri() ? x.AvatarUrl : string.Format("{0}{1}", x.FirstName.FirstOrDefault(), x.LastName.FirstOrDefault())),
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName,
                Date = x.Date,
                IsAuthor = x.IsAuthor,
                Answers = x.Answers.Select(y => new GetAllChatItemDto()
                {
                    Id = y.Id,
                    Text = y.Text,
                    ParentId = y.ParentId,
                    UserId = y.UserId,
                    IsAvatarUrl = string.IsNullOrEmpty(y.AvatarUrl) ? false : y.AvatarUrl.IsValidUri(),
                    Avatar = y.AvatarUrl == null ? string.Format("{0}{1}", y.FirstName.FirstOrDefault(), y.LastName.FirstOrDefault()) : (y.AvatarUrl.IsValidUri() ? y.AvatarUrl : string.Format("{0}{1}", y.FirstName.FirstOrDefault(), y.LastName.FirstOrDefault())),
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    SecondName = y.SecondName,
                    Date = y.Date,
                    IsAuthor = y.IsAuthor

                }).ToHashSet()

            }).ToHashSet();
        }
    }
}
