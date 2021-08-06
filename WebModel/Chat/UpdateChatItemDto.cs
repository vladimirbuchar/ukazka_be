using System;
using WebModel.Shared;

namespace WebModel.Answer
{
    public class UpdateChatItemDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string UserAccessToken { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
