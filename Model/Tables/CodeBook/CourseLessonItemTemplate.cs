using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct CourseLessonItemTemplateValues
    {
        public const string POWER_POINT = "POWER_POINT";
    }

    [Table("Cb_CourseLessonItemTemplate")]
    public class CourseLessonItemTemplate : CodeBook
    {
    }
}
