using Model.Tables.CodeBook;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_OrganizationStudyHour")]
    public class OrganizationStudyHour : TableModel
    {
        public virtual int Position { get; set; }
        public virtual TimeTable ActiveFrom { get; set; }
        public virtual TimeTable ActiveTo { get; set; }
    }
}