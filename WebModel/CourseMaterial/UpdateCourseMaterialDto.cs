using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class UpdateCourseMaterialDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
