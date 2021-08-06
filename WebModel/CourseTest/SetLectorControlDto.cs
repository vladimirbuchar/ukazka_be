
using System;
using WebModel.Shared;

namespace WebModel.CourseTest
{
    public class SetLectorControlDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public bool IsTrue { get; set; }
        public Guid QuestionId { get; set; }
        public string UserAccessToken { get; set; }
        public int Score { get; set; }
        public Guid StudentTestResultId { get; set; }


    }
}
