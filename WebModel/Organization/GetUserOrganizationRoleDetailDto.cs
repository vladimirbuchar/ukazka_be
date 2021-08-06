using System;
using System.Collections.Generic;

namespace WebModel.Organization
{
    public class GetUserOrganizationRoleDetailDto
    {
        public GetUserOrganizationRoleDetailDto()
        {
            Id = new HashSet<Guid>();
        }
        public HashSet<Guid> Id { get; set; }
    }
}
