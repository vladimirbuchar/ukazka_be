using System;
using WebModel.Shared;

namespace WebModel.User
{
    public class ChangePasswordDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid UserId { get; set; }
        public string OldUserPassword { get; set; }
        public string NewUserPassword { get; set; }
        public string NewUserPassword2 { get; set; }
        public string UserAccessToken { get; set; }
    }
}
