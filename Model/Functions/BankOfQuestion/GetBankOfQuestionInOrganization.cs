using System;

namespace Model.Functions.BankOfQuestion
{
    public class GetBankOfQuestionInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public int Position { get; set; }
    }
}
