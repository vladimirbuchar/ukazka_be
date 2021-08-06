using Model.Tables.Link;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_AttendanceStudent")]
    public class AttendanceStudent : TableModel
    {
        public virtual CourseTermDate CourseTermDate { get; set; }
        public virtual CourseStudent CourseStudent { get; set; }
        public virtual CourseTerm CourseTerm { get; set; }
    }
}
