using System;

namespace WebModel.Student
{
    public class GetAllStudentInCourseTermDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Guid StudentId { get; set; }
        public string Email { get; set; }
        public bool CourseFinish { get; set; }
    }
}
