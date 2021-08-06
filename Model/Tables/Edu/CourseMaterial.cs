using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseMaterial")]
    public class CourseMaterial : TableModel
    {
        public virtual Model.Tables.Shared.BasicInformation BasicInformation { get; set; }
        public virtual List<CourseLesson> CourseLessons { get; set; }
    }
}
