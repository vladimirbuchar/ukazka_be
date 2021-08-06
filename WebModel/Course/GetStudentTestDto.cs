using Model.Functions.CourseStudent;
using Model.Functions.CourseTerm;
using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Course
{
    public class GetStudentTestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Finish { get; set; }
        public double Score { get; set; }
        public bool TestCompleted { get; set; }
        public Guid TestId { get; set; }
        public Guid CourseMaterialId { get; set; }
        public Guid CourseId { get; set; }
    }
    public class GetStudentAttendanceDto
    {
        public GetStudentAttendanceDto()
        {
            TimeTable = new HashSet<GetTimeTable>();
            Student = new HashSet<GetAllStudentInCourseTerm>();
            StudentAttendance = new HashSet<StudentAttendance>();
        }
        public HashSet<GetTimeTable> TimeTable { get; set; }
        public HashSet<GetAllStudentInCourseTerm> Student { get; set; }
        public HashSet<StudentAttendance> StudentAttendance { get; set; } // student guid, term guid
    }
    public class StudentAttendance
    {
        public Guid StudentId { get; set; }
        public Guid TermId { get; set; }
        public bool IsActive { get; set; }
    }
    public class GetStudentEvaluationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Evaluation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string UserEmail { get; set; }
    }
    public class AddStudentEvaluationDto:BaseDto, IBaseDtoWithUserAccessToken
    {
        public string Evaluation { get; set; }
        public Guid UserInOrganizationId { get; set; }
        public Guid CourseTermId { get; set; }
        public string UserAccessToken { get; set; }
    }
}
