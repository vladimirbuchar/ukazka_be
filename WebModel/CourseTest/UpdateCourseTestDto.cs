using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.CourseTest
{
    public class UpdateCourseTestDto : BaseDto, IBaseDtoWithUserAccessToken, IBasicInformationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string UserAccessToken { get; set; }
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public List<Guid> BankOfQuestion { get; set; }
        public int MaxRepetition { get; set; }

    }
}
