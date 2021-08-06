using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Organization
{

    public class UpdateUserInOrganizationRoleDto : IBaseDtoWithUserAccessToken
    {
        public List<Guid> OrganizationRoleId { get; set; }
        public string UserAccessToken { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
    }
}
