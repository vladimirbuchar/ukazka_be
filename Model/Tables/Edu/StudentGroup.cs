using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_StudentGroup")]
    public class StudentGroup : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }

    }
}
