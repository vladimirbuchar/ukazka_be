using System;
using WebModel.Shared;

namespace WebModel.User
{
    public class UserListItemDto : BaseDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public PersonDto PersonName { get; set; }
    }
}
