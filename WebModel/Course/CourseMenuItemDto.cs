using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace WebModel.Course
{
    public class CourseMenuItemDto
    {
        public CourseMenuItemDto()
        {
            Items = new HashSet<CourseMenuSubItemDto>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        private string _type { get; set; }
        public string Type
        {
            get => _type; set
            {
                _type = value;
                if (Items.Count > 0)
                {
                    _type = CourseLessonType.SUB_ITEM;
                }
                if (string.IsNullOrEmpty(_type))
                {
                    _type = CourseLessonType.COURSE_ITEM;
                }
            }
        }
        public HashSet<CourseMenuSubItemDto> Items { get; set; }
    }
}
