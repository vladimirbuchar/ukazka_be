using System;
using WebModel.Shared;

namespace WebModel.User
{
    public class ActivateUserDto : BaseDto
    {
        public Guid UserId { get; set; }
    }
}
