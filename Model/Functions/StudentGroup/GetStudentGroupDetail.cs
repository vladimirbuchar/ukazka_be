using System;

namespace Model.Functions.SendMessage
{
    public class GetStudentGroupDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
