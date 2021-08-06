using System;

namespace Model.Functions.SendMessage
{
    public class GetCourseMaterialDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class GetFiles: SqlFunction
    {
        public Guid Id { get; set; }
        public Guid ObjectOwner { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
    }
}
