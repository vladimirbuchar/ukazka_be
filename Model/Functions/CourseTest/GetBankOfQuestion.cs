using System;

namespace Model.Functions.CourseTest
{
    public class GetBankOfQuestion : SqlFunction
    {
        public Guid Id { get; set; }
        public Guid BankOfQuestionId { get; set; }
    }
}
