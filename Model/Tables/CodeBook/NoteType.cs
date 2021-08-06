using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{

    public struct NoteTypeValues
    {
        public static string NOTE_TYPE_TEXT = "NOTE_TYPE_TEXT";
        public static string NOTE_TYPE_DRAW = "NOTE_TYPE_DRAW";
    }
    [Table("Cb_NoteType")]
    public class NoteType : CodeBook
    {
    }
}
