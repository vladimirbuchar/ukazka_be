﻿using System;
using WebModel.Shared;

namespace WebModel.Category
{
    public class CategoryListItemDto : BaseDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid ParentCategory { get; set; }
        public string CategoryIdentificator { get; set; }
    }
}
