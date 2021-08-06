using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_TestUserAnswer")]
    public class TestUserAnswer : TableModel
    {
        public StudentTestSummary StudentTestSummary { get; set; }
        public TestQuestion TestQuestion { get; set; }
        public TestQuestionAnswer TestQuestionAnswer { get; set; }
    }
}
