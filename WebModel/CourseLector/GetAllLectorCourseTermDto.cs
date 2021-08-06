﻿using System;
using WebModel.Shared;

namespace WebModel.CourseLector
{
    public class GetAllLectorCourseTermDto : BaseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
    }
}
