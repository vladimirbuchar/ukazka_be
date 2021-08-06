using System;

namespace Model.Functions.User
{
    public class GetUserDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid PersonId { get; set; }
        public string AvatarUrl { get; set; }

    }
    public class GetMyAttendance : SqlFunction
    {
        //public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string TimeTo { get; set; }
        public string TimeFrom { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        //public Guid CourseTermDateId { get; set; }
        //public DateTime Date { get; set; }
        // public int Priority { get; set; }
    }
}
