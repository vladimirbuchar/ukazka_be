using WebModel.Shared;

namespace WebModel.User
{
    public class GeneratePasswordResetEmailDto : BaseDto, IBaseDtoWithClientCulture
    {
        public string UserEmail { get; set; }
        public string ClientCulture { get; set; }
    }
}
