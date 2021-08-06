using System;
using WebModel.Shared;

namespace WebModel.SendMessage
{
    public class GetCourseMaterialDetailDto : IBasicInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class GetFilesDto: BaseDto
    {
        public Guid Id { get; set; }
        public Guid ObjectOwner { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public string Url { get; set; }
    }
}
