using System;
using WebModel.Shared;

namespace WebModel.Answer
{
    public class AddChatItemDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string UserAccessToken { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseTermId { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
    }
}
