using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Course
{
    public class EvaluateTestDto : IBaseDtoWithUserAccessToken
    {
        public EvaluateTestDto()
        {
            EvaluateQuestions = new List<EvaluateQuestionDto>();
        }
        public Guid? UserTestSummaryId { get; set; }
        public List<EvaluateQuestionDto> EvaluateQuestions { get; set; }
        public string UserAccessToken { get; set; }
        public Guid CourseLessonId { get; set; }
    }
    public class ResetCourseDto : IBaseDtoWithUserAccessToken
    {
        public Guid StudentTermId { get; set; }
        public string UserAccessToken { get; set; }
    }
    public class UpdateActualTableDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string Img { get; set;}
        public Guid CourseTermId { get; set; }
        public string UserAccessToken { get; set; }
    }
    public class CreateLiveBroadcastEventDto: BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid CourseTermId { get; set; }
        public string UserAccessToken { get; set; }
    }



}
