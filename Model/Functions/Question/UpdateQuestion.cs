﻿using System;

namespace Model.Functions.Question
{
    public class UpdateQuestion
    {
        public string Question { get; set; }
        public Guid AnswerModeId { get; set; }
        public Guid Id { get; set; }
        public Guid BankOfQuestionId { get; set; }
        public Guid QuestionModeId { get; set; }
    }
}
