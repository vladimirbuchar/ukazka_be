using System;

namespace WebModel.Course
{
    public class GetAllSlideIdDto
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }

    }
}
