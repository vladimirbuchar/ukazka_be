using System;
using System.Collections.Generic;

namespace WebModel.Course
{
    public class EvaluateQuestionDto
    {
        public EvaluateQuestionDto()
        {
            AnswerId = new List<Guid>();
        }
        public Guid QuestionId { get; set; }
        public List<Guid> AnswerId { get; set; }
        public string TextAnswer { get; set; }
        public string TextManualAnswer { get; set; }

    }


}
