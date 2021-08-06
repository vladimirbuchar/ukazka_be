using System;
using WebModel.Shared;

namespace WebModel.Answer
{
    public class GetAnswerDetailDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; }
    }
}
