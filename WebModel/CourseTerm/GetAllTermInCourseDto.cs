using Model.Tables.CodeBook;
using System;
using WebModel.Shared;

namespace WebModel.CourseTerm
{
    public class GetAllTermInCourseDto : BaseDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        private string _timeTo;
        public string TimeTo
        {
            get
            {
                if (_timeTo == CodeBookValues.CODEBOOK_SELECT_VALUE)
                {
                    return "";
                }
                return _timeTo;
            }
            set => _timeTo = value;
        }


        private string _timeFrom;
        public string TimeFrom
        {
            get
            {
                if (_timeFrom == CodeBookValues.CODEBOOK_SELECT_VALUE)
                {
                    return "";
                }
                return _timeFrom;
            }
            set => _timeFrom = value;
        }
        public string ClassRoom { get; set; }
        public string Branch { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string Name => string.Format("{2} - {3} {0} {11} {1} {4} {5} {6} {7} {8} {9} {10}", TimeFrom, TimeTo, ActiveFrom.ToString("dd.MM.yyyy"), ActiveTo.ToString("dd.MM.yyyy")
                    , Monday ? "CORSE_TERM_MONDAY " : "", Tuesday ? "CORSE_TERM_TUESDAY " : "", Wednesday ? "CORSE_TERM_WEDNESDAY " : "", Thursday ? "CORSE_TERM_THURSDAY " : "",
                    Friday ? "COURSE_TERM_FRIDAY " : "", Saturday ? "COURSE_TERM_SATURDAY " : "", Sunday ? "COURSE_TERM_SUNDAY " : "", TimeFrom != "" && TimeTo != "" ? " - " : ""
                    );
        public Guid BranchId { get; set; }
        public Guid ClassRoomId { get; set; }
        public bool IsActive { get; set; }
    }
}
