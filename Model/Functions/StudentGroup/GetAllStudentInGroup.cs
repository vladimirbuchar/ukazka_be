using System;

namespace Model.Functions.CourseStudent
{
    public class GetAllStudentInGroup : SqlFunction
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string UserEmail { get; set; }
    }
    public class GetAllTermInGroup : SqlFunction
    {
        public Guid CourseTermId { get; set; }
    }
}
