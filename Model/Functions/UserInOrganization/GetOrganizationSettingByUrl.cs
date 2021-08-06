using System;

namespace Model.Functions.UserInOrganization
{
    public class GetOrganizationSettingByUrl : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }
    }
}
