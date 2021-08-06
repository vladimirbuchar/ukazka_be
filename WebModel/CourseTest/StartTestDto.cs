using System;
using WebModel.Shared;

namespace WebModel.CourseTest
{
    public class StartTestDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string UserAccessToken { get; set; }
        public Guid CourseLessonId { get; set; }
        public Guid CourseId { get; set; }
    }
}
