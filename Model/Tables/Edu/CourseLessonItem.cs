﻿using Model.Tables.CodeBook;
using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseLessonItem")]
    public class CourseLessonItem : TableModel
    {
        [Column("Html")]
        public virtual string Html { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual CourseLessonItemTemplate CourseLessonItemTemplate { get; set; }
        [Column("Position")]
        public virtual int Position { get; set; } = 0;
        [Column("Youtube")]
        public string Youtube { get; set; }
    }
}
