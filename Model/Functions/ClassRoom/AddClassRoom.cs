﻿using System;

namespace Model.Functions.ClassRoom
{
    public class AddClassRoom
    {
        public int Floor { get; set; }
        public int MaxCapacity { get; set; }
        public Guid BranchId { get; set; }
        public string BasicInformationName { get; set; }
        public string BasicInformationDescription { get; set; }
        public bool IsOnline { get; set; }
    }
}
