using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{

    [Table("Edu_User")]
    public class User : TableModel
    {
        [Column("UserEmail")]
        public virtual string UserEmail { get; set; }

        [Column("UserPassword")]
        public virtual string UserPassword { get; set; }

        [Column("UserToken")]
        public virtual string UserToken { get; set; }
        public virtual Person Person { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual string FacebookId { get; set; }
        public virtual string GoogleId { get; set; }
        public virtual IEnumerable<LinkLifeTime> LinkLifeTime { get; set; }
    }
}
