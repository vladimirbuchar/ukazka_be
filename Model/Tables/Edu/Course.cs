using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Course")]
    public class Course : TableModel
    {
        [Column("IsPrivateCourse")]
        public virtual bool IsPrivateCourse { get; set; } = false;
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual CoursePrice CoursePrice { get; set; }
        public virtual StudentCount StudentCount { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual CourseStatus CourseStatus { get; set; }
        public virtual IEnumerable<CourseTerm> CourseTerm { get; set; }
        public virtual IEnumerable<CourseRate> CourseRate { get; set; }
        public virtual bool AutomaticGenerateCertificate { get; set; }
        public virtual Certificate Certificate { get; set; }
        public virtual CourseMaterial CourseMaterial { get; set; }
        public virtual bool SendEmail { get; set; }
        public virtual SendMessage SendMessage { get; set; }
        public virtual bool CourseWithLector { get; set; }

    }
}