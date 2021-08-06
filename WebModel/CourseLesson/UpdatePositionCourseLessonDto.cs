using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class UpdatePositionCourseLessonDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public List<string> Ids { get; set; }
        public string UserAccessToken { get; set; }
    }
}
