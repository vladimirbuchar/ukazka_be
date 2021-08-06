using Model.Tables.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_Category")]
    public class Category : TableModel
    {
        public virtual BasicInformation BasicInformation { get; set; }
        public virtual HashSet<Category> ChildCategory { get; set; }
        public virtual HashSet<Course> Course { get; set; }
    }
}