using WebModel.Shared;

namespace WebModel.Notification
{
    public class SetIsNewNotificationToFalseDto : IBaseDtoWithUserAccessToken
    {
        public string UserAccessToken { get; set; }
    }
}
