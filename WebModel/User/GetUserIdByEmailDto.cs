using WebModel.Shared;

namespace WebModel.User
{
    public class GetUserIdByEmailDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string UserEmail { get; set; }
        public string UserAccessToken { get; set; }
    }
}
