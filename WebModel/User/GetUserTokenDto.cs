using WebModel.Shared;

namespace WebModel.User
{
    public class GetUserTokenDto : BaseDto
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string OrganizationId { get; set; }
    }
}
