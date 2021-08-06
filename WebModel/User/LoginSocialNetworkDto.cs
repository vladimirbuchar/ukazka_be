﻿using WebModel.Shared;

namespace WebModel.User
{
    public class LoginSocialNetworkDto : BaseDto
    {
        public string UserEmail { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string OrganizationId { get; set; }


    }
}
