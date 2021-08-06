using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Test
{
    public class EvaluateTestResponseDto : BaseDto
    {
        public bool TestCompleted { get; set; }
        public List<EvaluateQuestionDto> Questions { get; set; }

    }
}
