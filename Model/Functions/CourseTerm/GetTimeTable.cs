using System;

namespace Model.Functions.CourseTerm
{
    public class GetTimeTable : SqlFunction
    {
        public Guid Id { get; set; }
        public bool IsCanceled { get; set; }
        public string DayOfWeek { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string ClassRoom { get; set; }
        public string UserEmail { get; set; }
        public bool IsFinishTerm => Date.Date < DateTime.Now.Date;

    }
    public class GetAllTimeInCourseTerm : SqlFunction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
    public class GetStudentEvaluation : SqlFunction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Evaluation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string UserEmail { get; set; }
    }
    public class AddStudentEvaluation
    {
        public string Evaluation { get; set; }
        public Guid UserInOrganizationId { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
