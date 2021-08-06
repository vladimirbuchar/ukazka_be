using System;

namespace Model.Functions.Answer
{
    public class GetAnswersInQuestion : SqlFunction
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsTrueAnswer { get; set; }
        public int Position { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public Guid ObjectOwner { get; set; }

    }
}
