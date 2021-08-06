using Model.Functions.CourseStudent;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseStudentRepository
{
    public interface ICourseStudentRepository : IBaseRepository
    {
        HashSet<GetAllStudentInCourseTerm> GetAllStudentInCourseTerm(Guid courseTermId);
        void AddStudentToCourseTerm(AddStudentToCourseTerm addStudentToCourseTerm);
        HashSet<GetMyCourse> GetStudentCourse(Guid userId);
    }
}
