﻿using System;
using WebModel.Shared;

namespace WebModel.Organization
{
    public class GetOrganizationListDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
