using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Tables.Edu
{
    [Table("Edu_StudentEvaluation")]
    public class StudentEvaluation:TableModel
    {
        public virtual UserInOrganization UserInOrganization { get; set; }
        public virtual DateTime Date { get; set;} 
        public virtual string Evaluation { get; set; }
        public virtual CourseTerm CourseTerm { get; set; }
    }
}
