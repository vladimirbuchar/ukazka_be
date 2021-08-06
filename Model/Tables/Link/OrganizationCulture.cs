using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Link_OrganizationCulture")]
    public class OrganizationCulture : TableModel
    {
        public virtual Organization Organization { get; set; }
        public virtual CodeBook.Culture Culture { get; set; }
        public virtual bool IsDefault { get; set; }
    }
}
