using System;
using WebModel.Shared;

namespace WebModel.Category
{
    public class GetCategoryDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid ParentCategory { get; set; }
        public string CategoryIdentificator { get; set; }
        public string Description { get; internal set; }
    }
}
