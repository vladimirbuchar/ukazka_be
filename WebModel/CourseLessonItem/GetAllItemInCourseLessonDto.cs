using System;
using WebModel.Shared;

namespace WebModel.CourseLessonItem
{
    public class GetCourseLessonItemsDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
