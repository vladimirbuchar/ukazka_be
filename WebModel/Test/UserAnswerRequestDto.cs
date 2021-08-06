using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Test
{
    public class UserAnswerRequestDto : BaseDto
    {
        public Guid QuestionId { get; set; }
        public List<Guid> UserAnswers { get; set; }

    }
}
