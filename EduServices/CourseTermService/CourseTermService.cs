using Core.DataTypes;
using EduRepository.CourseTermRepository;
using Model.Functions.CourseTerm;
using Model.Functions.User;
using Model.Tables.Edu;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EduServices.CourseTermService
{
    public class CourseTermService : BaseService, ICourseTermService
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermService(ICourseTermRepository courseTermRepository)
        {
            _courseTermRepository = courseTermRepository;
        }
        public Guid AddCourseTerm(AddCourseTerm addCourseTerm)
        {
            return _courseTermRepository.AddCourseTerm(addCourseTerm);
        }

        public void UpdateCourseTerm(UpdateCourseTerm updateCourseTerm)
        {
            _courseTermRepository.UpdateCourseTerm(updateCourseTerm);
        }

        public void DeleteCourseTerm(Guid courseTermId)
        {
            _courseTermRepository.DeleteEntity<CourseTerm>(courseTermId);
        }

        public HashSet<GetAllTermInCourse> GetAllTermInCourse(Guid courseId)
        {
            return _courseTermRepository.GetAllTermInCourse(courseId).OrderByDescending(x => x.IsActive).ToHashSet();
        }

        public GetCourseTermDetail GetCourseTermDetail(Guid courseTermId)
        {
            return _courseTermRepository.GetCourseTermDetail(courseTermId);
        }



        public void ValidateCourseDate(DateTime? activeFrom, DateTime? activeTo, DateTime? registrationFrom, DateTime? registrationTo, Result validate)
        {
            if (registrationFrom != null && registrationTo != null && registrationTo < registrationFrom)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "REGISTRATION_TO_IS_SMALLER_THEN_REGISTRATION_FROM"));
            }
            if (activeFrom != null && activeTo != null && activeTo < activeFrom)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "ACTIVE_TO_IS_SMALLER_THEN_ACTIVE_FROM"));
            }
        }
        public void StudentValidation(int minimumStudent, int maximumStudent, int classRoomCapacity, Result validate)
        {
            if (maximumStudent < minimumStudent)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "MAXIMUM_STUDENTS_IS_LESS_THEN_MINIMUM_STUDENTS"));
            }
            if (maximumStudent > classRoomCapacity && classRoomCapacity > 0)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "MAXIMUM_STUDENTS_IS_MORE_THEN_CAPACITY_CLASS_ROOM"));
            }
        }

        public HashSet<GetAllStudentGroupInTerm> GetAllStudentGroupInTerm(Guid courseTermId)
        {
            return _courseTermRepository.GetAllStudentGroupInTerm(courseTermId);
        }

        public void DeleteStudentGroupFromTerm(Guid id)
        {
            _courseTermRepository.DeleteEntity<StudentInGroupCourseTerm>(id);
        }

        public void AddStudentGroupToTerm(AddStudentGroupToTerm addStudentGroupToTerm)
        {
            _courseTermRepository.AddStudentGroupToTerm(addStudentGroupToTerm);
        }

        public void GenerateTimeTable(DateTime activeFrom, DateTime activeTo, Guid timeFromId, Guid timeToId, List<bool> days, Guid courseTermId, List<string> lectors, Guid classRoomId)
        {
            DateTime activeFromDate = activeFrom.Date;
            DateTime activeToDate = activeTo.Date;
            bool monday = days[0];
            bool tuesday = days[1];
            bool wednesday = days[2];
            bool thursday = days[3];
            bool friday = days[4];
            bool saturday = days[5];
            bool sunday = days[6];
            DateTime nextDay = activeFromDate;

            while (nextDay <= activeToDate)
            {
                foreach (string lector in lectors)
                {
                    if (monday && nextDay.DayOfWeek == DayOfWeek.Monday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_MONDAY", Guid.Parse(lector), classRoomId);
                    }
                    if (tuesday && nextDay.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_TUESDAY", Guid.Parse(lector), classRoomId);
                    }
                    if (wednesday && nextDay.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_WEDNESDAY", Guid.Parse(lector), classRoomId);
                    }
                    if (thursday && nextDay.DayOfWeek == DayOfWeek.Thursday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_THURSDAY", Guid.Parse(lector), classRoomId);
                    }
                    if (friday && nextDay.DayOfWeek == DayOfWeek.Friday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_FRIDAY", Guid.Parse(lector), classRoomId);
                    }
                    if (saturday && nextDay.DayOfWeek == DayOfWeek.Saturday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_SATURDAY", Guid.Parse(lector), classRoomId);
                    }
                    if (sunday && nextDay.DayOfWeek == DayOfWeek.Sunday)
                    {
                        _courseTermRepository.GenerateTimeTable(courseTermId, nextDay, timeFromId, timeToId, "COURSE_TIMETABLE_SUNDAY", Guid.Parse(lector), classRoomId);
                    }
                }
                nextDay = nextDay.AddDays(1);
            }
        }

        public void DeleteTimeTable(Guid timeTableId)
        {
            _courseTermRepository.DeleteEntity<CourseTermDate>(timeTableId);
        }

        public HashSet<GetTimeTable> GetTimeTable(Guid courseTermId)
        {
            return _courseTermRepository.GetTimeTable(courseTermId).OrderBy(x => x.IsFinishTerm).ToHashSet();
        }

        public void CancelCourseTerm(Guid courseTermTimeTableId)
        {
            _courseTermRepository.CancelCourseTerm(courseTermTimeTableId);
        }

        public void RestoreCourseTerm(Guid courseTermTimeTableId)
        {
            _courseTermRepository.RestoreCourseTerm(courseTermTimeTableId);
        }

        public void SaveStudentAttendance(Guid studentId, Guid timeTableId, Guid courseTermId, bool isActive)
        {
            _courseTermRepository.SaveStudentAttendance(studentId, timeTableId, courseTermId, isActive);
        }

        public HashSet<GetStudentAttendance> GetStudentAttendance(Guid courseTermId)
        {
            return _courseTermRepository.GetStudentAttendance(courseTermId);
        }

        public GetMyAttendance GetMyAttendance(Guid courseStudentId, Guid courseTermDateId)
        {
            return _courseTermRepository.GetMyAttendance(courseStudentId, courseTermDateId);
        }
        public HashSet<GetAllTimeInCourseTerm> GetAllTimeInCourseTerm(Guid courseTermId)
        {
            return _courseTermRepository.GetAllTimeInCourseTerm(courseTermId);
        }

        public HashSet<GetStudentEvaluation> GetStudentEvaluation(Guid courseTermId)
        {
            return _courseTermRepository.GetStudentEvaluation(courseTermId);
        }

        public void AddStudentEvaluation(AddStudentEvaluation addStudentEvaluation)
        {
            _courseTermRepository.AddStudentEvaluation(addStudentEvaluation);
        }
    }
}
