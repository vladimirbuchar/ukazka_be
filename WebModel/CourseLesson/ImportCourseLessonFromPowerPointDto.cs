using System;
using WebModel.Shared;

namespace WebModel.CourseLesson
{
    public class ImportCourseLessonFromPowerPointDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid ObjectOwner { get; set; }
        public Guid FileId { get; set; }
        public string UserAccessToken { get; set; }

    }
}
