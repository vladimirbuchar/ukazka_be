using System;
using WebModel.Shared;

namespace WebModel.ClassRoom
{
    public class UpdateClassRoomDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
