using Model.Tables.Edu;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_CouseStudentMaterial")]
    public class CouseStudentMaterial : TableModel
    {
        public virtual User User { get; set; }
        public virtual Guid CourseLessonItem { get; set; }
        public virtual Course Course { get; set; }
    }
}
