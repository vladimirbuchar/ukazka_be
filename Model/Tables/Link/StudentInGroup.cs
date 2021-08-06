using Model.Tables.Edu;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Link
{
    [Table("Link_StudentInGroup")]
    public class StudentInGroup : TableModel
    {
        public virtual UserInOrganization User { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }
}
