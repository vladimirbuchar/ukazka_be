﻿using System;
using WebModel.Shared;

namespace WebModel.ClassRoom
{
    public class GetAllClassRoomInBranchDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOnline { get; set; }
    }
}
