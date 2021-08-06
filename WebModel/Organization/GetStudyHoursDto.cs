using System;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class GetStudyHoursDto : BaseDto
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string ActiveFrom { get; set; }
        public string ActiveTo { get; set; }
        public int Position { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }

    }
}