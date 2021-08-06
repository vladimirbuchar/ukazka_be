using System;
using WebModel.Shared;

namespace WebModel.Test
{
    public class UpdateTestRequestDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool RandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
    }
}
