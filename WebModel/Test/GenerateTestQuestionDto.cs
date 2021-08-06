using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Test
{
    public class GenerateTestQuestionDto : BaseDto
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public List<GenerateTestAnswerDto> Answers { get; set; }
    }
}
