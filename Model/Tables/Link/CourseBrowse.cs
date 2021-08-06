using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Link_CourseBrowse")]
    public class CourseBrowse : TableModel
    {
        public virtual Course Course { get; set; }
        public virtual CourseLessonItem CourseLessonItem { get; set; }
        public virtual User User { get; set; }

    }
}
