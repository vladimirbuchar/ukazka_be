using System;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class UpdateStudyHoursDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string ActiveFromId { get; set; }
        public string ActiveToId { get; set; }
        public int Position { get; set; }
        public string UserAccessToken { get; set; }
    }
}