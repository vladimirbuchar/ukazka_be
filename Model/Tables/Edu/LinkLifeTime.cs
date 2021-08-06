using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_LinkLifeTime")]
    public class LinkLifeTime : TableModel
    {
        [Column("EndTime")]
        public virtual DateTime EndTime { get; set; }
    }
}
