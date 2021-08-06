using System;
using WebModel.Shared;

namespace WebModel.Course
{
    public class UpdateCourseDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public CoursePriceDto Price { get; set; }
        public string CourseImage { get; set; }
        public int DefaultMinimumStudents { get; set; }
        public int DefaultMaximumStudents { get; set; }
        public Guid CourseTypeId { get; set; }
        public Guid CourseStatusId { get; set; }
        public Guid OrganizationId { get; set; }
        public bool IsPrivateCourse { get; set; } = false;
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CertificateId { get; set; }
        public bool AutomaticGenerateCertificate { get; set; }
        public string CourseMaterialId { get; set; }
        public bool SendEmail { get; set; }
        public string EmailTemplateId { get; set; }
        public bool CourseWithLector { get; set; }
    }
}
