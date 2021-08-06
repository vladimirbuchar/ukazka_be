using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.CourseTest
{
    public class GetCourseTestDetailDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public HashSet<Guid> BankOfQuestion { get; set; }
        public int MaxRepetition { get; set; }
    }

}
