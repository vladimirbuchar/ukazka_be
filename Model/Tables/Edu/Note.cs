using Model.Tables.CodeBook;
using Model.Tables.Link;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Note")]
    public class Note : TableModel
    {
       public string Text { get; set; }
        public virtual Course Course { get; set; }
        public virtual  NoteType NoteType { get; set; }
        public virtual User User { get; set; }
        public string NoteName { get; set; }
        public string FileName { get; set; }

    }
}
