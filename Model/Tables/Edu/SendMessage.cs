using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_SendMessage")]
    public class SendMessage : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual string Html { get; set; }
        public virtual SendMessageType SendMessageType { get; set; }
        public virtual string Reply { get; set; }
    }
}