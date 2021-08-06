using System;

namespace Model.Functions.SendMessage
{
    public class GetStudentGroupInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
