using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    public struct CourseLessonType
    {
        public static string COURSE_ITEM = "COURSE_ITEM";
        public static string COURSE_TEST = "COURSE_TEST";
        public static string SUB_ITEM = "SUB_ITEM";
        public static string COURSE_ITEM_POWER_POINT = "COURSE_ITEM_POWER_POINT";
        public static string LAST_SLIDE = "LAST_SLIDE";
    }
    [Table("Edu_CourseLesson")]
    public class CourseLesson : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        [Column("Position")]
        public virtual int Position { get; set; } = 0;
        [Column("Type")]
        public virtual string Type { get; set; }
        public virtual string PowerPointFile { get; set; }

        public virtual IEnumerable<CourseLessonItem> CourseItem { get; set; }
    }
}
