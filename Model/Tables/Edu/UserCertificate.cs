using Model.Tables.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_UserCertificate")]
    public class UserCertificate : TableModel
    {
        public virtual User User { get; set; }
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual string FileName { get; set; }
        public virtual DateTime ActiveFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }

    }
}
