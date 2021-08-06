using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_StudentTestSummaryQuestion")]
    public class StudentTestSummaryQuestion : TableModel
    {
        public virtual StudentTestSummary StudentTestSummary { get; set; }
        public virtual List<StudentTestSummaryAnswer> StudentTestSummaryAnswers { get; set; }
        public virtual string Question { get; set; }
        public virtual AnswerMode AnswerMode { get; set; }
        public virtual int Score { get; set; }
        public virtual bool IsTrue { get; set; }
        public virtual bool IsAutomaticEvaluate { get; set; }
        public virtual int Position { get; set; }
        public virtual TestQuestion TestQuestion { get; set; }
        public virtual QuestionMode QuestionMode { get; set; }
        public virtual string FilePath { get; set; }
    }
}
