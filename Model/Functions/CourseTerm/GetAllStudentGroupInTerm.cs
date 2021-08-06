using System;

namespace Model.Functions.CourseTerm
{
    public class GetAllStudentGroupInTerm : SqlFunction
    {
        public Guid Id { get; set; }
        public Guid CourseTermId { get; set; }
        public Guid StudentGroupId { get; set; }
    }
    public class GetStudentAttendance : SqlFunction
    {
        public Guid CourseTermDateId { get; set; }
        public Guid CourseStudentId { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
    }
}
