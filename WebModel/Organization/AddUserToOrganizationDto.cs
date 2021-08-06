using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class AddUserToOrganizationDto : BaseDto, IBaseDtoWithUserAccessToken, IBaseDtoWithClientCulture
    {
        public List<string> UserEmails { get; set; }
        public Guid OrganizationId { get; set; }
        public List<Guid> OrganizationRoleId { get; set; }
        public string UserAccessToken { get; set; }
        public string ClientCulture { get; set; }
    }
}