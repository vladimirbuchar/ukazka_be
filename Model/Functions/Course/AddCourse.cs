﻿using System;

namespace Model.Functions.Course
{
    public class AddCourse
    {
        public Guid CourseTypeId { get; set; }
        public Guid CourseStatusId { get; set; }
        public bool IsPrivateCourse { get; set; }
        public Guid OrganizationId { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
        public double CoursePrice { get; set; }
        public int CoursePriceSale { get; set; }
        public int StudentCountMinimumStudent { get; set; }
        public int StudentCountMaximumStudent { get; set; }
        public Guid? CertificateId { get; set; } = null;
        public bool AutomaticGenerateCertificate { get; set; }
        public Guid? CourseMaterialId { get; set; }
        public bool SendEmail { get; set; }
        public Guid? EmailTemplateId { get; set; }
        public bool CourseWithLector { get; set; }
    }
}
