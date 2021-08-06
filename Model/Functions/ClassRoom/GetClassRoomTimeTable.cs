using System;

namespace Model.Functions.ClassRoom
{
    public class GetClassRoomTimeTable : SqlFunction
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public bool Monday { get; set; }
        public bool Thursday { get; set; }
        public bool Wednesday { get; set; }
        public bool Tuesday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public Guid TimeFromId { get; set; }
        public Guid TimeToId { get; set; }




    }
}
