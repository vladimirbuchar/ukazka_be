using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Chat")]
    public class Chat : TableModel
    {
        
        public virtual User User { get; set; }
        public virtual CourseTerm CourseTerm { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Chat Parent { get; set; }

    }
}