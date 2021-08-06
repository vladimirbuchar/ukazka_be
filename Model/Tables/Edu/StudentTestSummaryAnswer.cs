using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_StudentTestSummaryAnswer")]
    public class StudentTestSummaryAnswer : TableModel
    {
        [Column("Answer")]
        public virtual string Answer { get; set; }
        [Column("IsTrueAnswer")]
        public virtual bool IsTrueAnswer { get; set; }
        public virtual string UserTestAnswer { get; set; }
        public virtual bool UserAnswer { get; set; }
        public virtual int Position { get; set; }
        public virtual bool UserAnswerIsCorrect { get; set; }
        public virtual TestQuestionAnswer TestQuestionAnswer { get; set; }
        public virtual string FilePath { get; set; }
        public virtual string UserTestImageAnswer { get; set; }
    }
}
