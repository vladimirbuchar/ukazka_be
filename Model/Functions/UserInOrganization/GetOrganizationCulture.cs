using System;

namespace Model.Functions.UserInOrganization
{
    public class GetOrganizationCulture : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
