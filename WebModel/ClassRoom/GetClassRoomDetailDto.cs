using System;
using System.Collections.Generic;
using WebModel.Organization;
using WebModel.Shared;
using WebModel.User;

namespace WebModel.ClassRoom
{
    public class GetClassRoomDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class GetClassRoomTimeTableDto : BaseDto
    {
        public GetClassRoomTimeTableDto()
        {
            StudyHours = new HashSet<GetStudyHoursDto>();
            TimeTable = new HashSet<TimeTableDto>();
        }
        public HashSet<GetStudyHoursDto> StudyHours { get; set; }
        public HashSet<TimeTableDto> TimeTable { get; set; }
    }
}
