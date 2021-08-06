using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    [Table("Cb_Culture")]
    public class Culture : CodeBook
    {
        public virtual bool IsEnvironmentCulture { get; set; }

    }
}
