using System;

namespace Model.Functions.CourseTest
{
    public class GetStudentTest : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Finish { get; set; }
        public double Score { get; set; }
        public bool TestCompleted { get; set; }
        public Guid TestId { get; set; }
        public Guid CourseMaterialId { get; set; }
        public Guid CourseId { get; set; }
    }
}
