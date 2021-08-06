using System;

namespace Model.Functions.CourseTest
{
    public class GetAllStudentTestResult : SqlFunction
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public DateTime? Finish { get; set; }
        public double Score { get; set; }
        public bool TestCompleted { get; set; }
    }
}
