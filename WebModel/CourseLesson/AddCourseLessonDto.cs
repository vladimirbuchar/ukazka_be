using Model.Tables.Edu;
using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class AddCourseLessonDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MaterialId { get; set; }
        public string UserAccessToken { get; set; }
        public string Type { get; set; } = CourseLessonType.COURSE_ITEM;
    }
}
