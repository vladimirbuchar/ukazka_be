using System;
using WebModel.Shared;

namespace WebModel.Test
{
    public class GenerateTestAnswerDto : BaseDto
    {
        public Guid AnswerId { get; set; }
        public string Answer { get; set; }
    }
}
