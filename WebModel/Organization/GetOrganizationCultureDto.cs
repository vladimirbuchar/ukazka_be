using System;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class GetOrganizationCultureDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}