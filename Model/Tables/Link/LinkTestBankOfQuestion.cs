using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_TestBankOfQuestion")]
    public class LinkTestBankOfQuestion : TableModel
    {
        public virtual BankOfQuestion BankOfQuestion { get; set; }
        public virtual CourseTest CourseTest { get; set; }
    }
}
