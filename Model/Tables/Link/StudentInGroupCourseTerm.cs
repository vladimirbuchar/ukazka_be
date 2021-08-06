using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_StudentInGroupCourseTerm")]
    public class StudentInGroupCourseTerm : TableModel
    {
        public virtual CourseTerm CourseTerm { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }
}
