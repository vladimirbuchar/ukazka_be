using System;

namespace Model.Functions.Course
{
    public class GetCourseDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public bool IsPrivateCourse { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Sale { get; set; }
        public Guid CourseStatusId { get; set; }
        public Guid CourseTypeId { get; set; }
        public string FileName { get; set; }
        public int MinimumStudent { get; set; }
        public int MaximumStudent { get; set; }
        public Guid CertificateId { get; set; }
        public bool AutomaticGenerateCertificate { get; set; }
        public Guid CourseMaterialId { get; set; }
        public Guid SendMessageId { get; set; }
        public bool SendEmail { get; set; }
        public bool CourseWithLector { get; set; }
    }
    public class GetCourseTermByCourseStudent : SqlFunction
    {
        public Guid CourseTermId { get; set; }
    }



}
