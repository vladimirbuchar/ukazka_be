using System;
using System.Collections.Generic;

namespace Model.Functions.CourseTest
{
    public class GetCourseTestDetail : SqlFunction
    {
        public GetCourseTestDetail()
        {
            BankOfQuestion = new HashSet<GetBankOfQuestion>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRandomGenerateQuestion { get; set; }
        public int QuestionCountInTest { get; set; }
        public int TimeLimit { get; set; }
        public int DesiredSuccess { get; set; }
        public HashSet<GetBankOfQuestion> BankOfQuestion { get; set; }
        public Guid TestId { get; set; }
        public int MaxRepetition { get; set; }
    }
}
