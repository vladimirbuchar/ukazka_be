using System;

namespace Model.Functions.CourseStudent
{
    public class GetMyCourse : SqlFunction
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public Guid UserId { get; set; }
        public string ClassRoom { get; set; }
        public string BranchName { get; set; }
        public bool Monday { get; set; }
        public bool Thursday { get; set; }
        public bool Wednesday { get; set; }
        public bool Tuesday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string OrganizationName { get; set; }
        public Guid TermId { get; set; }
        public Guid CourseStudentId { get; set; }
        public bool CourseFinish { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid TimeFromId { get; set; }
        public Guid TimeToId { get; set; }

    }
}
