﻿using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class GetStudentGroupInOrganizationDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
