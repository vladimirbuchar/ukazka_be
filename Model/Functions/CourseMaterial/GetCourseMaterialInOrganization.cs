using System;

namespace Model.Functions.SendMessage
{
    public class GetCourseMaterialInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
