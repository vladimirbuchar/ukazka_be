using System;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class GetOrganizationSettingByUrlDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }

    }
}
