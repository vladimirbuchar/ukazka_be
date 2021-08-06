using System;

namespace WebModel.User
{
    public class GetUserByAccessTokenDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
    }
}
