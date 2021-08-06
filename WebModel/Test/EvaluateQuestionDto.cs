using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Test
{
    public class EvaluateQuestionDto : BaseDto
    {
        public Guid QuestionId { get; set; }
        public bool IsOk { get; set; }
        public List<Guid> TrueAnswers { get; set; }

    }
}
