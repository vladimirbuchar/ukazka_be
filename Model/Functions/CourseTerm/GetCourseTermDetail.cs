﻿using System;

namespace Model.Functions.CourseTerm
{
    public class GetCourseTermDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public DateTime RegistrationFrom { get; set; }
        public DateTime RegistrationTo { get; set; }
        public Guid ClassRoomId { get; set; }
        public Guid BranchId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid TimeFromId { get; set; }
        public Guid TimeToId { get; set; }
        public double Price { get; set; }
        public int Sale { get; set; }
        public int MaximumStudent { get; set; }
        public int MinimumStudent { get; set; }
        public Guid OrganizationStudyHourId { get; set; }
    }
}
