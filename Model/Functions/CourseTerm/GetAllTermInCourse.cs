using System;

namespace Model.Functions.CourseTerm
{
    public class GetAllTermInCourse : SqlFunction
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string TimeTo { get; set; }
        public string TimeFrom { get; set; }
        public string ClassRoom { get; set; }
        public string Branch { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid BranchId { get; set; }
        public Guid ClassRoomId { get; set; }
        public bool IsActive => DateTime.Now.Date <= ActiveTo.Date;

    }
}
