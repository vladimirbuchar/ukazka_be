using System;

namespace Model.Functions.File
{
    public class GetFileDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Guid ObjectOwner { get; set; }
    }
}
