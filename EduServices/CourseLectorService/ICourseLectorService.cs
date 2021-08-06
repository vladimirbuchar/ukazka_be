using Model.Functions.CourseLector;
using Model.Functions.CourseStudent;
using System;
using System.Collections.Generic;

namespace EduServices.CourseLectorService
{
    public interface ICourseLectorService : IBaseService
    {
        void AddCourseLector(AddCourseLector addCourseLector);
        void DeleteCourseTermLector(Guid courseLectorTemId);
        HashSet<CourseTermLector> GetAllLectorCourseTerm(Guid courseTermId);
        HashSet<GetMyCourse> GetLectorCourse(Guid userId);


    }
}
