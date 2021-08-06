using Model.Tables.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Certificate")]
    public class Certificate : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual string Html { get; set; }
        public virtual int CertificateValidTo { get; set; }
    }
}