using Model.Functions.CourseLector;
using Model.Functions.CourseStudent;
using System;
using System.Collections.Generic;

namespace EduRepository.CourseLectorRepository
{
    public interface ICourseLectorRepository : IBaseRepository
    {
        HashSet<CourseTermLector> GetAllLectorCourseTerm(Guid courseTermId);
        void AddCourseLector(AddCourseLector addCourseLector);
        HashSet<GetMyCourse> GetLectorCourse(Guid userId);

    }
}
