using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseTest")]
    public class CourseTest : TableModel
    {
        [Column("IsRandomGenerateQuestion")]
        public virtual bool IsRandomGenerateQuestion { get; set; }

        [Column("QuestionCountInTest")]
        public virtual int QuestionCountInTest { get; set; }

        [Column("TimeLimit")]
        public virtual int TimeLimit { get; set; }

        [Column("DesiredSuccess")]
        public virtual int DesiredSuccess { get; set; }
        [Column("MaxRepetition")]
        public virtual int MaxRepetition { get; set; }
        public virtual CourseLesson CourseLesson { get; set; }

    }
}
