using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Student;

namespace EduFacade.CourseStudentFacade
{
    public interface ICourseStudentFacade : IBaseFacade
    {
        Result AddStudentToCourseTerm(AddStudentToCourseTermDto addStudentToCourseTermDto, Guid organizationId);
        HashSet<GetAllStudentInCourseTermDto> GetAllStudentInCourseTerm(Guid courseTermId);
        void DeleteStudentFromCourseTerm(Guid courseStudentTermId);

    }
}
