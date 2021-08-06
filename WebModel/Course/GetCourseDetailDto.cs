using System;
using WebModel.Shared;

namespace WebModel.Course
{
    public class GetCourseDetailDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public bool IsPrivateCourse { get; set; }
        public CoursePriceDto CoursePrice { get; set; }
        public Guid CourseStatusId { get; set; }
        public Guid CourseTypeId { get; set; }
        public string CourseType { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinimumStudent { get; set; }
        public int MaximumStudent { get; set; }
        public Guid CertificateId { get; set; }
        public bool AutomaticGenerateCertificate { get; set; }
        public Guid CourseMaterialId { get; set; }
        public Guid SendMessageId { get; set; }
        public bool SendEmail { get; set; }
        public bool CourseWithLector { get; set; }
    }
}
