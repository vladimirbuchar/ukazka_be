using Model.Tables.CodeBook;
using Model.Tables.Link;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_CourseTermDate")]
    public class CourseTermDate : TableModel
    {
        public DateTime Date { get; set; }
        public bool IsCanceled { get; set; }
        public virtual TimeTable TimeFrom { get; set; }
        public virtual TimeTable TimeTo { get; set; }
        public virtual string DayOfWeek { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public virtual UserInOrganization UserInOrganization { get; set; }

    }
}
