using System;
using System.Collections.Generic;
using WebModel.Organization;
using WebModel.Shared;

namespace WebModel.User
{
    public class GetUserDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public PersonDto Person { get; set; }
    }
    public class GetMyTimeTableDto : BaseDto
    {
        public GetMyTimeTableDto()
        {
            StudyHours = new HashSet<GetStudyHoursDto>();
            TimeTable = new HashSet<TimeTableDto>();
        }
        public string OrganizationName { get; set; }
        public HashSet<GetStudyHoursDto> StudyHours { get; set; }
        public bool HaveStudyHours { get; set; }
        public HashSet<TimeTableDto> TimeTable { get; set; }
    }
    public class TimeTableDto
    {
        public TimeTableDto()
        {
            CourseTerm = new List<string>();
        }
        public string DayOfWeek { get; set; }
        public List<string> CourseTerm { get; set; }
    }
    public class GetMyAttendanceDto : BaseDto
    {
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsActive { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string CourseName { get; set; }
    }


}
