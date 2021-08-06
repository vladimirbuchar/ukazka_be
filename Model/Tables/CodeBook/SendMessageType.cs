using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct SendMessageTypeValue
    {
        public static string SMS = "SMS";
        public static string EMAIL = "EMAIL";
    }
    [Table("Cb_SendMessageType")]
    public class SendMessageType : CodeBook
    {

    }
}
