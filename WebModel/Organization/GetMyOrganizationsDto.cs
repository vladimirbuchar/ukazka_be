using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class GetMyOrganizationsDto : BaseDto
    {
        public GetMyOrganizationsDto()
        {
            OrganizationRole = new List<OrganizationRoleDto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OrganizationRoleDto> OrganizationRole { get; set; }


    }
}