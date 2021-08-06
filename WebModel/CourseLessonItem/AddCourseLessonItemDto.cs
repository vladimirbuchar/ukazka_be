using System;
using WebModel.Shared;

namespace WebModel.CourseLessonItem
{
    public class AddCourseLessonItemDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public Guid CourseLessonId { get; set; }
        public string Html { get; set; }

        public string UserAccessToken { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TemplateId { get; set; }
        public string Youtube { get; set; }
    }
}
