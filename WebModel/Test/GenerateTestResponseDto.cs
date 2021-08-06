using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Test
{
    public class GenerateTestResponseDto : BaseDto
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Name { get; set; }
        public List<GenerateTestQuestionDto> Questions { get; set; }
        public int TimeLimit { get; set; }
    }
}
