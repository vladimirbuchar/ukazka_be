using System;
using WebModel.Shared;

namespace WebModel.User
{
    public class SetNewPasswordDto : BaseDto
    {
        public Guid LinkId { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
