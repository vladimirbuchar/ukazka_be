using System;
using WebModel.Shared;

namespace WebModel.User
{
    public class LoginUserDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public bool? IsAvatarUrl { get; set; } = false;
        public string Avatar { get; set; } = "";
        public string FullName { get; set; } = "";
    }

}
